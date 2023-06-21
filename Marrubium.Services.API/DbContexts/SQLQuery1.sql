INSERT INTO products(Name, Price, InternalProductTypes, InternalFunctions, InternalSkinTypes, ImageUrl, Description)
VALUES
('Cream with retinol', 1000, 'Lotion', 'Rejuvenating,Restoring', 'Soft', 'https://images.bsite.net/products/1_1.png', ''),
('Lotion with centella', 1500, 'Serum', 'Rejuvenating', 'Soft,Sensitive', 'https://images.bsite.net/products/1_2.png', ''),
('Serum with green tea', 1200, 'Serum', 'Restoring', 'Soft', 'https://images.bsite.net/products/1_3.png', ''),
('Serum with wormwood', 1600, 'Serum', 'Restoring', 'Soft', 'https://images.bsite.net/products/1_3.png', ''),
('Scrub with vanilla', 900, 'Cleaning', 'Rejuvenating,Restoring', 'Soft,Sensitive', 'https://images.bsite.net/products/2_1.png', ''),
('Under-eye cream', 2000, 'Lotion', 'Rejuvenating,Restoring', 'Sensitive', 'https://images.bsite.net/products/2_2.png', ''),
('Cream with mint', 1000, 'Lotion', 'Rejuvenating', 'Soft,Sensitive', 'https://images.bsite.net/products/2_3.png', ''),
('Clay mask with matcha', 800, 'Mask', 'Restoring', 'Sensitive', 'https://images.bsite.net/products/2_4.png', ''),
('The handle of the shovel', 500, 'Mask', 'Restoring', 'Rough', 'https://images.bsite.net/products/3_1.png', ''),
('Garage', 10000, 'Cleaning', 'Rejuvenating,Restoring', 'Rough', 'https://images.bsite.net/products/3_2.png', ''),
('Russian hotdog', 50, 'Serum', 'Rejuvenating,Restoring', 'Rough', 'https://images.bsite.net/products/3_3.png', '');

SELECT * FROM Products

TRUNCATE TABLE Products