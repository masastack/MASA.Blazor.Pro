using BlazorComponent;

namespace MASA.Blazor.Pro.Data
{
    public class ShopDataItem
    {
        public ShopDataItem(string name, double price, string pictureFile, string category, int rating, string brand, string description, Guid? guid = null)
        {
            Id = guid ?? Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            PictureFile = pictureFile;
            Category = category;
            Rating = rating;
            Brand = brand;
        }

        public Guid Id { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }

        public double Price { get; init; }

        public string PictureFile { get; init; }

        public string Category { get; set; }

        public int Rating { get; set; }

        public string Brand { get; set; }
    }

    public static class ShopDataService
    {
        public static List<ShopDataItem> ShopDataItems = new List<ShopDataItem>
        {
            new("Apple Watch Series 5",339.99,"/img/apps-eCommerce/1.png","Cell Phones",4,"Apple","On Retina display that never sleeps, so it’s easy to see the time and other important information, without raising or tapping the display. New location features, from a built-in compass to current elevation, help users better navigate their day, while international emergency calling1 allows customers to call emergency services directly from Apple Watch in over 150 countries, even without iPhone nearby. Apple Watch Series 5 is available in a wider range of materials, including aluminium, stainless steel, ceramic and an all-new titanium.",Guid.Parse("2d1e3440-5134-40c8-836f-f988bfef91c8")),
            new("Apple iPhone 11 (64GB, Black)",669.99,"/img/apps-eCommerce/2.png","Cell Phones",5,"Apple","The Apple iPhone 11 is a great smartphone, which was loaded with a lot of quality features. It comes with a waterproof and dustproof body which is the key attraction of the device. The excellent set of cameras offer excellent images as well as capable of recording crisp videos. However, expandable storage and a fingerprint scanner would have made it a perfect option to go for around this price range."),
            new("Apple iMac 27-inch",999.99,"/img/apps-eCommerce/3.png","Computers & Tablets",4,"Apple","The all-in-one for all. If you can dream it, you can do it on iMac. It’s beautifully & incredibly intuitive and packed with tools that let you take any idea to the next level. And the new 27-inch model elevates the experience in way, with faster processors and graphics, expanded memory and storage, enhanced audio and video capabilities, and an even more stunning Retina 5K display. It’s the desktop that does it all — better and faster than ever."),
            new("OneOdio A71 Wired Headphones",49.99,"/img/apps-eCommerce/4.png","Audio",3,"OneOdio","Omnidirectional detachable boom mic upgrades the headphones into a professional headset for gaming, business, podcasting and taking calls on the go. Better pick up your voice. Control most electric devices through voice activation, or schedule a ride with Uber and order a pizza. OneOdio A71 Wired Headphones voice-controlled device turns any home into a smart device on a smartphone or tablet."),
            new("Apple - MacBook Air® (Latest Model) - 13.3 Display - Silver",999.99,"/img/apps-eCommerce/5.png","Computers & Tablets",4,"Apple","MacBook Air is a thin, lightweight laptop from Apple. MacBook Air features up to 8GB of memory, a fifth-generation Intel Core processor, Thunderbolt 2, great built-in apps, and all-day battery life.1 Its thin, light, and durable enough to take everywhere you go-and powerful enough to do everything once you get there, better."),
            new("Switch Pro Controller",429.99,"/img/apps-eCommerce/6.png","Video Games",3,"Sharp","The Nintendo Switch Pro Controller is one of the priciest baseline controllers in the current console generation, but it's also sturdy, feels good to play with, has an excellent direction pad, and features impressive motion sensors and vibration systems. On top of all of that, it uses Bluetooth, so you don't need an adapter to use it with your PC."),
            new("Google - Google Home - White/Slate fabric",129.29,"/img/apps-eCommerce/7.png","Audio",4,"Google","Simplify your everyday life with the Google Home, a voice-activated speaker powered by the Google Assistant. Use voice commands to enjoy music, get answers from Google and manage everyday tasks. Google Home is compatible with Android and iOS operating systems, and can control compatible smart devices such as Chromecast or Nest."),
            new("Sony 4K Ultra HD LED TV",7999.99,"/img/apps-eCommerce/8.png","Computers & Tablets",5,"Apple","Sony 4K Ultra HD LED TV has 4K HDR Support. The TV provides clear visuals and provides distinct sound quality and an immersive experience. This TV has Yes HDMI ports & Yes USB ports. Connectivity options included are HDMI. You can connect various gadgets such as your laptop using the HDMI port. The TV comes with a 1 Year warranty."),
            new("OnePlus 7 Pro",14.99,"/img/apps-eCommerce/9.png","Cell Phones",4,"Philips","The OnePlus 7 Pro features a brand new design, with a glass back and front and curved sides. The phone feels very premium but’s it’s also very heavy. The Nebula Blue variant looks slick but it’s quite slippery, which makes single-handed use a real challenge. It has a massive 6.67-inch ‘Fluid AMOLED’ display with a QHD+ resolution, 90Hz refresh rate and support for HDR 10+ content. The display produces vivid colours, deep blacks and has good viewing angles."),
            new("Logitech K380 Wireless Keyboard",81.99,"/img/apps-eCommerce/10.png","Office & School Supplies",4,"Logitech","Logitech K380 Bluetooth Wireless Keyboard gives you the comfort and convenience of desktop typing on your smartphone, and tablet. It is a wireless keyboard that connects to all Bluetooth wireless devices that support external keyboards. Take this compact, lightweight, Bluetooth keyboard anywhere in your home. Type wherever you like, on any compatible computer, phone or tablet."),
            new("Nike Air Max",81.99,"/img/apps-eCommerce/11.png","Health, Fitness & Beauty",5,"Nike","With a bold application of colorblocking inspired by modern art styles, the Nike Air Max 270 React sneaker is constructed with layers of lightweight material to achieve its artful look and comfortable feel."),
            new("New Apple iPad Pro",799.99,"/img/apps-eCommerce/12.png","Computers & Tablets",3,"Apple","Up to 10 hours of surﬁng the web on Wi‑Fi, watching video, or listening to music. Up to 9 hours of surﬁng the web using cellular data network, Compatible with Smart Keyboard Folio and Bluetooth keyboards."),
            new("Vankyo leisure 3 mini projector",99.99,"/img/apps-eCommerce/13.png","TV & Home Theater",2,"Vankyo Store","SUPERIOR VIEWING EXPERIENCE: Supporting 1920x1080 resolution, VANKYO Leisure 3 projector is powered by MStar Advanced Color Engine, which is ideal for home entertainment. 2020 upgraded LED lighting provides a superior viewing experience for you."),
            new("Wireless Charger 5W Max",10.83,"/img/apps-eCommerce/14.png","Appliances",3,"3M","Charge with case: transmits charging power directly through protective cases. Rubber/plastic/TPU cases under 5 mm thickness . Do not use any magnetic and metal attachments or cards, or it will prevent charging."),
            new("Laptop Bag",29.99,"/img/apps-eCommerce/15.png","Office & School Supplies",5,"TAS","TSA FRIENDLY- A separate DIGI SMART compartment can hold 15.6 inch Laptop as well as 15 inch, 14 inch Macbook, 12.9 inch iPad, and tech accessories like charger for quick TSA checkpoint when traveling."),
            new("Adidas Mens Tech Response Shoes",54.59,"/img/apps-eCommerce/16.png","Health, Fitness & Beauty",5,"Adidas","Comfort + performance. Designed with materials that are durable, lightweight and extremely comfortable. Core performance delivers the perfect mix of fit, style and all-around performance."),
            new("Handbags for Women Large Designer bag",39.99,"/img/apps-eCommerce/17.png","Office & School Supplies",4,"Hobo","Classic Hobo Purse: Top zipper closure, with 2 side zipper pockets design and elegant tassels decoration, fashionable and practical handbags for women, perfect for shopping, dating, travel and business."),
            new("Oculus Quest All-in-one VR",645,"/img/apps-eCommerce/18.png","TV & Home Theater",1,"Oculus","All-in-one VR: No PC. No wires. No limits. Oculus quest is an all-in-one gaming system built for virtual reality. Now you can play almost anywhere with just a VR headset and controllers. Oculus touch controllers: arm yourself with the award-winning Oculus touch controllers. Your slashes, throws and grab appear in VR with intuitive, realistic Precision, transporting your hands and gestures right into the game"),
            new("Giotto 32oz Leakproof BPA Free Drinking Water",16.99,"/img/apps-eCommerce/19.png","Health, Fitness & Beauty",4,"3m","With unique inspirational quote and time markers on it,this water bottle is great for measuring your daily intake of water,reminding you stay hydrated and drink enough water throughout the day.A must have for any fitness goals including weight loss,appetite control and overall health."),
            new("PlayStation 4 Console",339.99,"/img/apps-eCommerce/20.png","Video Games",4,"Sony","All the greatest, games, TV, music and more. Connect with your friends to broadcast and celebrate your epic moments at the press of the Share button to Twitch, YouTube, Facebook and Twitter."),
            new("Bugani M90 Portable Bluetooth Speaker",56,"/img/apps-eCommerce/20.png","Audio",3,"Bugani","Bluetooth Speakers-The M90 Bluetooth speaker uses the latest Bluetooth 5.0 technology and the latest Bluetooth ATS chip, Connecting over Bluetooth in seconds to iPhone, iPad, Smart-phones, Tablets, Windows, and other Bluetooth devices."),
            new("Tile Pro - High Performance Bluetooth Tracker",29.99,"/img/apps-eCommerce/22.png","Office & School Supplies",4,"Tile","FIND KEYS, BAGS & MORE -- Pro is our high-performance finder ideal for keys, backpacks, luggage or any other items you want to keep track of. The easy-to-use finder and free app work with iOS and Android."),
            new("Toshiba Canvio Advance 2TB Portable External Hard Drive",69.99,"/img/apps-eCommerce/23.png","Computers & Tablets",2,"Toshiba","Up to 3TB of storage capacity to store your growing files and content."),
            new("Ronyes Unisex College Bag Bookbags for Women",23.99,"/img/apps-eCommerce/24.png","Office & School Supplies",2,"Ronyes","Made of high quality water-resistant material; padded and adjustable shoulder straps; external USB with built-in charging cable offers a convenient charging"),
            new("Willful Smart Watch for Men Women 2020",29.99,"/img/apps-eCommerce/25.png","Cell Phones",5,"Willful","Are you looking for a smart watch, which can not only easily keep tracking of your steps, calories, heart rate and sleep quality, but also keep you informed of incoming calls."),
            new("Rectangular Polarized, Bluetooth Audio Sunglasses",249,"/img/apps-eCommerce/26.png","Health, Fitness & Beauty",4,"Bose","Redesigned for luxury — Thoughtfully refined and strikingly elegant, the latest Bose sunglasses blend enhanced features and designs for an elevated way to listen."),
            new("VicTsing Wireless Mouse",10.99,"/img/apps-eCommerce/27.png","Computers & Tablets",3,"VicTsing","After thousands of samples of palm data, we designed this ergonomic mouse. The laptop mouse has a streamlined arc and thumb rest to help reduce the stress caused by prolonged use of the laptop mouse."),
        };
    }
}
