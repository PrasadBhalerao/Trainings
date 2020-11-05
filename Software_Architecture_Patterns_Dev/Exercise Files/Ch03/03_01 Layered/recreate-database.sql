CREATE TABLE Tour
(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1024) NULL,
    Image NVARCHAR(255) NULL
);

INSERT INTO Tour (Name, Description, Image)
VALUES
('Backpack Cal', 'Explore California our favorite way...by foot! Get outdoors and into the millions of acres of forests, desert, and spectacular scenery that California is famous for. We have a wide range of backpacking tour options, from single day-trips to week long guided excursions. Find a comfortable pair of shoes and come hiking with us!', 'back_bug.gif'),
('California Calm', 'Looking for a little relaxation? California Calm is our hand-picked collection of incredible California Spas and therapy retreats. Enjoy unbelievable massage treatments, beauty regimens, and active getaways. We''ve combed the entire state to find the finest spa experiences available...imagine that, we''ve even made choosing a spa retreat relaxing!', 'calm_desc_bug.gif'),
('Cycle California', 'Whether you are a hard-core mountain biking enthusiast, or just looking for a cool way to see the many scenic towns and vistas of our great state, Cycle California has a package for you! Explore the thousand of miles of biking trails from Big Sur all the way to the Southern California coast. Packages range from bring-your-own bike to full bike rental and travel days.', 'cycle_desc_bug.gif'),
('From Desert to Sea', 'Our most wide-ranging tour option! Come explore California from the stunning deserts all the way to our beautiful coast. Along the way you''ll travel through breathtaking mountain ranges and some of the nation''s most fertile farmland as you see why California is regarded as the most diverse state in the nation! Come see ALL that California has to offer!', 'desert_desc_bug.gif'),
('Kids California', 'Over and over again our customer support people would hear, "but what if we have kids?" when describing a tour. Then it hit us...why not create tours specifically for kids?! California is an amazing playground for everyone and should be experienced by all. From amazing museums, outstanding parks, Disney, and kid-centered nature experiences, Kids California truly has it all!', 'kids_desc_bug.gif'),
('Nature Watch', 'If you love the outdoors, nature, and the environment, California is the place for you! Our eco-tours range from watching seals and whales to exploring the desert for rare lizards and fauna. As inspirational as they are educational, our Nature Watch packages bring you the full range of California''s natural beauty.', 'nature_desc_bug.gif'),
('Snowboard Cali', 'California has some of the best snowboarding in the US and at Explore California we''ve combed the runs to offer you the best resorts in the state. We even offer multi-resort packages for those that just can''t get enough of that pack and grind. See you on the slopes!', 'snow_desc_bug.gif'),
('Taste of California', 'Tour of the wine country? Tour of the olive groves? We couldn''t decide so we put them together in one of our most amazing tour packages ever. Taste of California immerses you in the serene, romantic lifestyle of the California wine country and olive groves. Along the way you''ll experience some of the best cuisine in the world, all made from fresh local ingredients by some of the nation''s most renown chefs. Bon Appetit!', 'taste_desc_bug.gif');

CREATE TABLE Booking
(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TourId INT NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Transport INT NOT NULL,
    FOREIGN KEY(TourId) REFERENCES Tour(Id)
);
