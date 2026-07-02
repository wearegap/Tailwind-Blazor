using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Infrastructure.Data;

/// <summary>
/// Seeds the in-memory database with all reference data translated from the
/// Microsoft.TailWindTraders.Product SQL script.  Idempotent: returns immediately
/// if brands already exist.
/// </summary>
public static class InMemoryDataSeeder
{
    public static async Task SeedAsync(IDbContextFactory<AppDbContext> factory)
    {
        await using var db = await factory.CreateDbContextAsync();
        if (await db.Productbrands.AnyAsync()) return;

        db.Productbrands.AddRange(SeedBrands());
        db.Tag.AddRange(SeedTags());
        db.Producttypes.AddRange(SeedTypes());
        db.Productitems.AddRange(SeedItems());
        db.Productfeatures.AddRange(SeedFeatures());

        await db.SaveChangesAsync();
    }

    // ─── Brands ──────────────────────────────────────────────────────────────

    private static IEnumerable<ProductbrandsDto> SeedBrands() =>
    [
        new() { Id = 1, Name = "ElctroDrill" },
        new() { Id = 2, Name = "Home & Pro tools" },
        new() { Id = 3, Name = "Pro Saws" },
        new() { Id = 4, Name = "Drills Co" },
    ];

    // ─── Tags ─────────────────────────────────────────────────────────────────

    private static IEnumerable<TagDto> SeedTags() =>
    [
        new() { Id = 1, Value = "Rechargeable Screwdriver" },
        new() { Id = 2, Value = "Multitool" },
        new() { Id = 3, Value = "HardHat" },
    ];

    // ─── Product Types ────────────────────────────────────────────────────────

    private static IEnumerable<ProducttypesDto> SeedTypes() =>
    [
        new() { Id = 1, Name = "Home Appliances",    Code = "homeappliances" },
        new() { Id = 2, Name = "Sink",               Code = "sink" },
        new() { Id = 3, Name = "Home",               Code = "home" },
        new() { Id = 4, Name = "Gardening",          Code = "gardening" },
        new() { Id = 5, Name = "Decor",              Code = "decor" },
        new() { Id = 6, Name = "Kitchen Accessories",Code = "kitchen" },
        new() { Id = 7, Name = "DIY tools",          Code = "diytools" },
    ];

    // ─── Product Items ────────────────────────────────────────────────────────

    private static IEnumerable<ProductitemsDto> SeedItems() =>
    [
        new() { Id = 1,  Name = "Microwave 0.9 Cu. Ft. 900 W",                              Price = 100,  Imagename = "10446729.jpg",  Brandid = 1, Typeid = 1, Tagid = null },
        new() { Id = 2,  Name = "Refrigerator 1.7 cu. ft. 110 watts",                       Price = 200,  Imagename = "24640268.jpg",  Brandid = 3, Typeid = 1, Tagid = null },
        new() { Id = 3,  Name = "Oven 900 W",                                               Price = 300,  Imagename = "26881473.jpg",  Brandid = 4, Typeid = 1, Tagid = null },
        new() { Id = 4,  Name = "Washing machine 1200rpm",                                  Price = 400,  Imagename = "31000074.jpg",  Brandid = 2, Typeid = 1, Tagid = null },
        new() { Id = 5,  Name = "Washing machine 900rpm",                                   Price = 300,  Imagename = "31285507.jpg",  Brandid = 1, Typeid = 1, Tagid = null },
        new() { Id = 6,  Name = "Kitchen stoves ",                                          Price = 1400, Imagename = "33641114.jpg",  Brandid = 2, Typeid = 1, Tagid = null },
        new() { Id = 7,  Name = "Refrigerator ft. 90 watts",                                Price = 400,  Imagename = "45808024.jpg",  Brandid = 3, Typeid = 1, Tagid = null },
        new() { Id = 8,  Name = "One Handle Stainless Steel Pull Out Kitchen Faucet",       Price = 20,   Imagename = "47090355.jpg",  Brandid = 3, Typeid = 1, Tagid = null },
        new() { Id = 9,  Name = "Bathing System Classic 18 in. H x 60 in. W x 32.5",       Price = 200,  Imagename = "12330912.jpg",  Brandid = 1, Typeid = 2, Tagid = null },
        new() { Id = 10, Name = "Showerhead 1.75 gpm",                                      Price = 40,   Imagename = "12866014.jpg",  Brandid = 1, Typeid = 2, Tagid = null },
        new() { Id = 11, Name = "Toilet 1.28 gal.",                                         Price = 180,  Imagename = "20155731.jpg",  Brandid = 1, Typeid = 2, Tagid = null },
        new() { Id = 12, Name = "Black Bathing System Classic 18 in. H x 60 in. W x 32.5", Price = 250,  Imagename = "24547395.jpg",  Brandid = 2, Typeid = 2, Tagid = null },
        new() { Id = 13, Name = "Bathroom Sink Faucet Waterfall",                           Price = 175,  Imagename = "25200686.jpg",  Brandid = 2, Typeid = 2, Tagid = null },
        new() { Id = 14, Name = "Bathroom Sink Faucet",                                     Price = 99,   Imagename = "40193368.jpg",  Brandid = 2, Typeid = 2, Tagid = null },
        new() { Id = 15, Name = "Bathroom Sink Faucet Classic",                             Price = 100,  Imagename = "40887643.jpg",  Brandid = 3, Typeid = 2, Tagid = null },
        new() { Id = 16, Name = "Showerhead 1.20 gpm",                                      Price = 125,  Imagename = "46028385.jpg",  Brandid = 3, Typeid = 2, Tagid = null },
        new() { Id = 17, Name = "Blend Solid White Sheer Curtains",                         Price = 110,  Imagename = "13778772.jpg",  Brandid = 3, Typeid = 3, Tagid = null },
        new() { Id = 18, Name = "Door Hardware Kit Single Door",                             Price = 120,  Imagename = "17031875.jpg",  Brandid = 4, Typeid = 3, Tagid = null },
        new() { Id = 19, Name = "White Sheer Curtains",                                     Price = 105,  Imagename = "27367695.jpg",  Brandid = 4, Typeid = 3, Tagid = null },
        new() { Id = 20, Name = "White Window",                                             Price = 120,  Imagename = "34744564.jpg",  Brandid = 4, Typeid = 3, Tagid = null },
        new() { Id = 21, Name = "Curtain Rod 48 in",                                        Price = 25,   Imagename = "35268457.jpg",  Brandid = 4, Typeid = 3, Tagid = null },
        new() { Id = 22, Name = "Steel Passage Door Knob",                                  Price = 10,   Imagename = "39689828.jpg",  Brandid = 1, Typeid = 3, Tagid = null },
        new() { Id = 23, Name = "White Door",                                               Price = 123,  Imagename = "40505435.jpg",  Brandid = 1, Typeid = 3, Tagid = null },
        new() { Id = 24, Name = "White Window Wood",                                        Price = 230,  Imagename = "46655256.jpg",  Brandid = 1, Typeid = 3, Tagid = null },
        new() { Id = 25, Name = "Indoor Kit Gardering",                                     Price = 70,   Imagename = "9470575.jpg",   Brandid = 3, Typeid = 4, Tagid = null },
        new() { Id = 26, Name = "Craftsman 100 ft. L x 5/8 in.",                            Price = 100,  Imagename = "12598356.jpg",  Brandid = 3, Typeid = 4, Tagid = null },
        new() { Id = 27, Name = "Metal Watering Can",                                       Price = 20,   Imagename = "12902526.jpg",  Brandid = 3, Typeid = 4, Tagid = null },
        new() { Id = 28, Name = "Steel Contractor Wheelbarrow",                             Price = 100,  Imagename = "13894399.jpg",  Brandid = 3, Typeid = 4, Tagid = null },
        new() { Id = 29, Name = "Craftsman 21 in. W 140",                                   Price = 200,  Imagename = "15365639.jpg",  Brandid = 3, Typeid = 4, Tagid = null },
        new() { Id = 30, Name = "Gardering",                                                Price = 10,   Imagename = "29201547.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 31, Name = "Celebrations C9",                                          Price = 10,   Imagename = "16658158.jpg",  Brandid = 2, Typeid = 5, Tagid = null },
        new() { Id = 32, Name = "Artificial Tree",                                          Price = 250,  Imagename = "23073793.jpg",  Brandid = 2, Typeid = 5, Tagid = null },
        new() { Id = 33, Name = "Celebrations C8",                                          Price = 5,    Imagename = "23536846.jpg",  Brandid = 2, Typeid = 5, Tagid = null },
        new() { Id = 34, Name = "Artificial Tree Big",                                      Price = 300,  Imagename = "23980448.jpg",  Brandid = 2, Typeid = 5, Tagid = null },
        new() { Id = 35, Name = "Wood Pack",                                                Price = 30,   Imagename = "31434677.jpg",  Brandid = 1, Typeid = 5, Tagid = null },
        new() { Id = 36, Name = "Wood Table",                                               Price = 395,  Imagename = "19806834.jpg",  Brandid = 1, Typeid = 6, Tagid = null },
        new() { Id = 37, Name = "Kitchen Stoves",                                           Price = 85,   Imagename = "27227580.jpg",  Brandid = 1, Typeid = 6, Tagid = null },
        new() { Id = 38, Name = "Kit Metal Casseroles",                                     Price = 125,  Imagename = "43229847.jpg",  Brandid = 4, Typeid = 6, Tagid = null },
        new() { Id = 39, Name = "Coffee Maker Red",                                         Price = 200,  Imagename = "52076809.jpg",  Brandid = 4, Typeid = 6, Tagid = null },
        new() { Id = 40, Name = "Extractor Steal",                                          Price = 135,  Imagename = "102013777.jpg", Brandid = 4, Typeid = 6, Tagid = null },
        new() { Id = 41, Name = "Wooden Commode",                                           Price = 50,   Imagename = "21610747.jpg",  Brandid = 1, Typeid = 7, Tagid = null },
        new() { Id = 42, Name = "Metal Shelving",                                           Price = 90,   Imagename = "39696958.jpg",  Brandid = 1, Typeid = 7, Tagid = null },
        new() { Id = 43, Name = "Big Metal Shelving",                                       Price = 99,   Imagename = "49460165.jpg",  Brandid = 2, Typeid = 7, Tagid = null },
        new() { Id = 44, Name = "Wooden Wardrobe",                                          Price = 120,  Imagename = "51716553.jpg",  Brandid = 2, Typeid = 7, Tagid = null },
        new() { Id = 45, Name = "Wooden Saw",                                               Price = 145,  Imagename = "11143240.jpg",  Brandid = 3, Typeid = 7, Tagid = null },
        new() { Id = 46, Name = "Measuring Tape",                                           Price = 123,  Imagename = "13168288.jpg",  Brandid = 3, Typeid = 7, Tagid = null },
        new() { Id = 47, Name = "Multi Function Drill",                                     Price = 159,  Imagename = "14805480.jpg",  Brandid = 2, Typeid = 7, Tagid = null },
        new() { Id = 48, Name = "Hammer",                                                   Price = 100,  Imagename = "19682904.jpg",  Brandid = 2, Typeid = 7, Tagid = null },
        new() { Id = 49, Name = "Screwdriver",                                              Price = 110,  Imagename = "51109515.jpg",  Brandid = 1, Typeid = 7, Tagid = null },
        new() { Id = 50, Name = "Pliers",                                                   Price = 105,  Imagename = "85167541.jpg",  Brandid = 1, Typeid = 7, Tagid = null },
        new() { Id = 51, Name = "Red multi-tool plier",                                     Price = 50,   Imagename = "34312289.jpg",  Brandid = 1, Typeid = 7, Tagid = 2 },
        new() { Id = 52, Name = "Blue multi-tool plier",                                    Price = 50,   Imagename = "19595793.jpg",  Brandid = 1, Typeid = 7, Tagid = 2 },
        new() { Id = 53, Name = "Stainless multi-tool plier",                               Price = 90,   Imagename = "35414723.jpg",  Brandid = 1, Typeid = 7, Tagid = 2 },
        new() { Id = 54, Name = "Yellow Rechargeable screwdriver",                          Price = 250,  Imagename = "8704649.jpg",   Brandid = 2, Typeid = 7, Tagid = 1 },
        new() { Id = 55, Name = "Red Rechargeable screwdriver",                             Price = 250,  Imagename = "6910004.jpg",   Brandid = 1, Typeid = 7, Tagid = 1 },
        new() { Id = 56, Name = "Rechargeable screwdriver with extra battery",              Price = 312,  Imagename = "63581524.jpg",  Brandid = 2, Typeid = 7, Tagid = 1 },
        new() { Id = 57, Name = "Yellow hard hat with tool bag pack",                       Price = 46,   Imagename = "59890052.jpg",  Brandid = 3, Typeid = 7, Tagid = 3 },
        new() { Id = 58, Name = "Single red garden gnome",                                  Price = 56,   Imagename = "6112251.jpg",   Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 59, Name = "Two red garden gnomes",                                    Price = 92,   Imagename = "10999322.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 60, Name = "One sat gnome",                                            Price = 34,   Imagename = "24639790.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 61, Name = "One sat on shoe gnome",                                    Price = 54,   Imagename = "24639792.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 62, Name = "One barrow gnome",                                         Price = 29,   Imagename = "34369812.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 63, Name = "One glasses gnome",                                        Price = 54,   Imagename = "34369851.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 64, Name = "One smiling gnome",                                        Price = 43,   Imagename = "38786528.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 65, Name = "Two singing gnomes",                                       Price = 65,   Imagename = "44333595.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 66, Name = "Two sleeping gnomes",                                      Price = 32,   Imagename = "76911883.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 67, Name = "Seven-pack gnomes",                                        Price = 250,  Imagename = "91797131.jpg",  Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 68, Name = "One afraid gnome",                                         Price = 39,   Imagename = "106662449.jpg", Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 69, Name = "One welcome gnome",                                        Price = 28,   Imagename = "106906828.jpg", Brandid = 2, Typeid = 4, Tagid = null },
        new() { Id = 70, Name = "Two smiling gnomes",                                       Price = 76,   Imagename = "106906834.jpg", Brandid = 2, Typeid = 4, Tagid = null },
    ];

    // ─── Product Features ─────────────────────────────────────────────────────

    private static IEnumerable<ProductfeaturesDto> SeedFeatures() =>
    [
        new() { Id = 1,  Productitemid = 1,  Title = "20 Litre",                    Description = "Create delicious meals with this 800 W manual microwave with a 20 Litre capacity" },
        new() { Id = 2,  Productitemid = 1,  Title = "Multipower",                  Description = "Six power levels including a defrost setting offers variety for your cooking requirements" },
        new() { Id = 3,  Productitemid = 1,  Title = "3 years guarantee",            Description = "3 years guarantee" },
        new() { Id = 4,  Productitemid = 1,  Title = "Key features",                Description = "20Litre capacity (0.7cu.ft) 800W microwave output 11 microwave power levels 99min timer Cooking end signal Auto cook menus Defrost setting Glass turntable Mirror door" },
        new() { Id = 5,  Productitemid = 1,  Title = "Triple Distribution System",  Description = "Meaning a more even and effective distribution of heat. Easytronics dial control" },
        new() { Id = 6,  Productitemid = 2,  Title = "Low Noise",                   Description = "Thermoelectric technology is almost silent, so your kitchen stays quiet" },
        new() { Id = 7,  Productitemid = 2,  Title = "Stylish",                     Description = "Stylish American Style, Side by side Fridge freezer with energy rating A+" },
        new() { Id = 8,  Productitemid = 2,  Title = "Great capacity",              Description = "510 litre capacity - holds 28 bags of food shopping" },
        new() { Id = 9,  Productitemid = 3,  Title = "Double Hotplate",             Description = "Enjoy the bonus feature of including 2 ceramic hotplates, which are positioned on the top of the mini oven and are suitable for use with any kind of pot, pan, and frying pan for boiling, steaming, warming, or frying." },
        new() { Id = 10, Productitemid = 3,  Title = "2-year warranty",             Description = "Shop with confidence. Your Oven with is covered by a 2 year manufacturer's warranty" },
        new() { Id = 11, Productitemid = 4,  Title = "9k capacity",                 Description = "9kg drum capacity " },
        new() { Id = 12, Productitemid = 4,  Title = "A+++",                        Description = "A+++ energy rating" },
        new() { Id = 13, Productitemid = 5,  Title = "1600rpm",                     Description = "1600rpm max spin speed " },
        new() { Id = 14, Productitemid = 5,  Title = "15 wash programmes ",         Description = "15 wash programmes " },
        new() { Id = 15, Productitemid = 6,  Title = "Silver",                      Description = "Colour Silver " },
        new() { Id = 16, Productitemid = 6,  Title = "Eco-Friendly ",               Description = "Eco-Friendly " },
        new() { Id = 17, Productitemid = 6,  Title = "Size",                        Description = "Approx. 27x27cm" },
        new() { Id = 18, Productitemid = 7,  Title = "Capacity",                    Description = "141 Litres Fridge Capacity" },
        new() { Id = 19, Productitemid = 8,  Title = "Interface",                   Description = " inlet: G1 / 2, outlet: G1 / 4." },
        new() { Id = 20, Productitemid = 9,  Title = "Leakproof",                   Description = "The shower arm diverter is made by top premium brass with disc cartridge for leakproof and durability warranty" },
        new() { Id = 21, Productitemid = 10, Title = "Pinhole",                     Description = "The pinhole is out of the water, the water is slender and soft, and there is no pain in the body. " },
        new() { Id = 22, Productitemid = 10, Title = "Interface",                   Description = "The interface is suitable for most home use, hoses, showers, and interfaces are 2cm in diameter. It is suitable for all types of water heaters. " },
        new() { Id = 23, Productitemid = 11, Title = "Portable battery",            Description = "Battery powered portable bidet (rechargeable) can be taken anywhere " },
        new() { Id = 24, Productitemid = 11, Title = "10 wash cycles",              Description = "Minimum 50 wash cycles between charge & 10 wash cycles per 1.5 litre reservoir " },
        new() { Id = 25, Productitemid = 11, Title = "Remote handset",              Description = "Operates from a simple remote handset " },
        new() { Id = 26, Productitemid = 12, Title = "Multifunction",               Description = "Not only ideal for dog shower in bathroom, but also can be used as handheld bidet for personal hygiene etc. " },
        new() { Id = 27, Productitemid = 12, Title = "Handheld dog shower",         Description = "Comes with handheld dog shower sprayer head, hand shower arm diverter" },
        new() { Id = 28, Productitemid = 13, Title = "Single and double tap",       Description = "Single tap type and double tap type available, fit for most of standard taps. " },
        new() { Id = 29, Productitemid = 13, Title = "Pet washing",                 Description = "Can be used for pet washing, help you to take care of your cat or dog at ease and keep them clean." },
        new() { Id = 30, Productitemid = 13, Title = "Light weight",                Description = "Light weight, soft and flexible, easy to install and convenient to use. " },
        new() { Id = 31, Productitemid = 14, Title = "Chrome finished",             Description = "Chrome finish to create a bright, highly reflective, guaranteed not to tarnish or corrode Bathroom Sink faucet " },
        new() { Id = 32, Productitemid = 14, Title = "Ceramic disc",                Description = "Ceramic disc cartridge for smooth and long lasting operation bathtub sink faucet " },
        new() { Id = 33, Productitemid = 15, Title = "Single handle",               Description = "Single handle easy control of hot and cold water, Single hole easy installation basin mixer tap " },
        new() { Id = 34, Productitemid = 15, Title = "Durable",                     Description = "Durable lead-free solid brass construction. waterfall widespread vintage style bathroom vessel sink mixer tap, tall body " },
        new() { Id = 35, Productitemid = 16, Title = "Chrome finished",             Description = "This universal bath shower head is made of high grade ABS. Chrome finish " },
        new() { Id = 36, Productitemid = 17, Title = "Ready made",                  Description = "Two Panels Per Package, Each panel measures 117 x 138cm Drop, Inner Diameter of the Each Ring Measures 4cm. " },
        new() { Id = 37, Productitemid = 18, Title = "Only hardware",               Description = "Only Hardware is sold, the door is not included. " },
        new() { Id = 38, Productitemid = 19, Title = "Thermal curtains",            Description = "These thermal blackout curtains are made of 100 percent polyester and are imported. " },
        new() { Id = 39, Productitemid = 20, Title = "3 Year Guarantee ",           Description = "3 Year Guarantee " },
        new() { Id = 40, Productitemid = 21, Title = "Telescoping rod",             Description = "Telescoping double rod has a 3/4-inch diameter front rod and 5/8-inch diameter back rod, and is available in 3 sizes to accommodate most windows " },
        new() { Id = 41, Productitemid = 21, Title = "Easy setup",                  Description = "Your Twilight double curtain rod comes with everything you need to get set up quickly and doesn't require a curtain rod bracket" },
        new() { Id = 42, Productitemid = 22, Title = "Brushed steel",               Description = "Brushed Stainless Steel Door Knob Handle Passage Entrance Privacy Thumb Lock " },
        new() { Id = 43, Productitemid = 23, Title = "Woodgrain effect ",           Description = "Woodgrain effect " },
        new() { Id = 44, Productitemid = 23, Title = "Primed finish-ready",         Description = "Primed finish-ready to paint" },
        new() { Id = 45, Productitemid = 24, Title = "Real wood",                   Description = "Natural real wood venetian blinds " },
        new() { Id = 46, Productitemid = 24, Title = "Metal brackets",              Description = "Metal brackets that can be top, side or face fixed " },
        new() { Id = 47, Productitemid = 25, Title = "9 plants size",               Description = "Up to 9 plants can be grown at a time. Plants grow in water, not soil. Advanced hydroponics made simple, Enjoy plants all year round. Grow fresh herbs, vegetables, salad leaves, flowers and more in this smart indoor garden " },
        new() { Id = 48, Productitemid = 26, Title = "Wood material",               Description = "Wood material" },
        new() { Id = 49, Productitemid = 27, Title = "Galvanised steel ",           Description = "Durable galvanised steel " },
        new() { Id = 50, Productitemid = 28, Title = "85L capacity",                Description = "Capacity: 85 Litres / 120 Kgs " },
        new() { Id = 51, Productitemid = 29, Title = "Tissue holder ",              Description = "Tissue holder " },
        new() { Id = 52, Productitemid = 30, Title = "Stainless fork",              Description = "Stainless Steel Weed Fork with 40-Inch Handle " },
        new() { Id = 53, Productitemid = 31, Title = "22cm high",                   Description = "Stands approx. 22cm high " },
        new() { Id = 54, Productitemid = 31, Title = "Tree pack",                   Description = "Christmas tree pack" },
        new() { Id = 55, Productitemid = 32, Title = "6 feet tall",                 Description = "6 feet tall Christmas Tree in plain green with 1000 tips, pvc material is suitable for both outdoor and indoor using. " },
        new() { Id = 56, Productitemid = 32, Title = "Foldable base",               Description = "Designed with a durable metal body to use season after season, plus a foldable base for easy assembly. " },
        new() { Id = 57, Productitemid = 33, Title = "Material",                    Description = "Green plastic" },
        new() { Id = 58, Productitemid = 34, Title = "9 feet tall",                 Description = "9 feet tall Christmas tree" },
        new() { Id = 59, Productitemid = 35, Title = "Natural pine",                Description = "Our natural wood slices are made of natural pine wood with barks and clearly visible wood grain." },
        new() { Id = 60, Productitemid = 35, Title = "High-quality",                Description = "Our wood slices were drying, slicing, and picking out high-quality wood chips" },
        new() { Id = 61, Productitemid = 36, Title = "Dining table",                Description = "A solid oak rectangular dining table in a durable oiled finish " },
        new() { Id = 62, Productitemid = 36, Title = "Dimensions",                  Description = "Dimensions (D x W x H): 118 x 75 x 75 cm " },
        new() { Id = 63, Productitemid = 37, Title = "Folding foot",                Description = "Folding foot, Piezo ignition, wind shield " },
        new() { Id = 64, Productitemid = 38, Title = "Double ceramic coating",      Description = "Double ceramic coating, aluminium cookware set " },
        new() { Id = 65, Productitemid = 39, Title = "Stylish machine",             Description = "Stylish bean-to-cup espresso/cappuccino machine with professional 15-bar pump pressure" },
        new() { Id = 66, Productitemid = 40, Title = "Ventilation mode",            Description = "Recirculation inside your kitchen with the use of carbon filters." },
        new() { Id = 67, Productitemid = 41, Title = "Small commode",               Description = "Upholstered commode chair is small, easier to move around the patient's room, at home or in clinical setting." },
        new() { Id = 68, Productitemid = 42, Title = "Easy setup",                  Description = "Provided with detailed instructions, the cubes are easy to assemble; and can be installed on the wall seamlessly with the screws and cloaking metal plates " },
        new() { Id = 69, Productitemid = 43, Title = "Large bay size",              Description = "1500mm High x 700mm Wide x 300mm Deep and capable of holding 180kg per shelf " },
        new() { Id = 70, Productitemid = 44, Title = "Modern design",               Description = "Wood-patterned closed doors and walls" },
        new() { Id = 71, Productitemid = 45, Title = "High carbon steel blade",     Description = "High carbon steel blade for use in hard-to-reach areas " },
        new() { Id = 72, Productitemid = 46, Title = "Tylon blade coating",         Description = "Tylon blade coating gives durability and wear resistance than lacquer" },
        new() { Id = 73, Productitemid = 47, Title = "Vibration absorbing handle ", Description = "Vibration absorbing handle " },
        new() { Id = 74, Productitemid = 48, Title = "Forged black",                Description = "Forged black painted head " },
        new() { Id = 75, Productitemid = 48, Title = "Polished faces",              Description = "Hardened and tempered with polished faces and hardwood shaft " },
        new() { Id = 76, Productitemid = 49, Title = "Chrome vanadium steel ",      Description = "Manufactured from chrome vanadium steel " },
        new() { Id = 77, Productitemid = 50, Title = "Hardened and tempered ",      Description = "Carbon steel hardened and tempered " },
    ];
}
