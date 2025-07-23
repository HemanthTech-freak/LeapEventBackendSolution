-- Insert Leap events project dummy events
INSERT INTO Events (Name, StartsOn, EndsOn, Location) VALUES
('Tech Conference', '2025-08-15 09:00', '2025-08-15 17:00', 'Toronto'),
('Music Festival', '2025-09-10 15:00', '2025-09-10 22:00', 'Vancouver'),
('Startup Meetup', '2025-07-28 18:00', '2025-07-28 21:00', 'Montreal');

-- Insert Leap events project dummy ticket sales
INSERT INTO TicketSales (EventId, UserId, PurchaseDate, PriceInCents) VALUES
("1", "101", '2025-07-20 12:30', 15000),
("1", "102", '2025-07-20 12:35', 15000),
("2", "103", '2025-07-21 14:00', 3000),
("2", "104", '2025-07-21 14:10', 3000),
("2", "105", '2025-07-21 14:20', 3000),
("3", "106", '2025-07-22 10:00', 1000);