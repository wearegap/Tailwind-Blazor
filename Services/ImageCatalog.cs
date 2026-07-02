using Microsoft.Extensions.FileProviders;

namespace ProductCatalog.Blazor.Services;

/// <summary>
/// Singleton that indexes wwwroot/images/ (recursively) once at startup.
/// Maps file stem -> relative web path so DB values without a folder prefix
/// (e.g. "102013777") resolve to the correct subdirectory file.
/// When multiple matches exist the first one wins (alphabetical by subpath).
/// </summary>
public sealed class ImageCatalog
{
    private static readonly string[] Extensions =
        [".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp"];

    // stem (no ext, lower) -> "/images/sub/file.jpg"
    private readonly Dictionary<string, string> _stemIndex;
    // full relative name (lower) -> "/images/sub/file.jpg"
    private readonly Dictionary<string, string> _pathIndex;

    public ImageCatalog(IWebHostEnvironment env)
    {
        _stemIndex = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        _pathIndex = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        IndexDirectory(env.WebRootFileProvider, "images", "/images");
    }

    private void IndexDirectory(IFileProvider fp, string physicalSubpath, string webPrefix)
    {
        var dir = fp.GetDirectoryContents(physicalSubpath);
        if (!dir.Exists) return;
        foreach (var entry in dir.OrderBy(e => e.Name, StringComparer.OrdinalIgnoreCase))
        {
            if (entry.IsDirectory)
            {
                IndexDirectory(fp, $"{physicalSubpath}/{entry.Name}", $"{webPrefix}/{entry.Name}");
            }
            else
            {
                var webPath = $"{webPrefix}/{entry.Name}";
                _pathIndex.TryAdd(entry.Name, webPath);
                var stem = Path.GetFileNameWithoutExtension(entry.Name);
                _stemIndex.TryAdd(stem, webPath);
            }
        }
    }

    public string? Resolve(string? imagename)
    {
        if (string.IsNullOrWhiteSpace(imagename)) return null;

        // 1. Exact filename match (e.g. "102013777.jpg")
        if (_pathIndex.TryGetValue(imagename, out var hit)) return hit;

        // 2. Subpath match (e.g. "product-details/102013777.jpg")
        var normalized = imagename.Replace('\\', '/');
        var filename = Path.GetFileName(normalized);
        if (_pathIndex.TryGetValue(filename, out hit)) return hit;

        // 3. Stem-only lookup
        var stem = Path.GetFileNameWithoutExtension(imagename);
        if (_stemIndex.TryGetValue(stem, out hit)) return hit;

        // 4. Try known extensions on the stem
        foreach (var ext in Extensions)
        {
            if (_pathIndex.TryGetValue(stem + ext, out hit)) return hit;
        }
        return null;
    }
}
