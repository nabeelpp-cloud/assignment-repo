CREATE DATABASE BookMyShow
USE BookMyShow


--Users
CREATE TABLE Users(
	UserId INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(25) NOT NULL,
	Email VARCHAR(25) NOT NULL UNIQUE,
	Phone VARCHAR(25) NOT NULL UNIQUE
);

--⦁	UserId
--⦁	Name
--⦁	Email
--⦁	Phone


--MovieLanguage
CREATE TABLE MovieLanguage(
	MovieLanguageId INT IDENTITY(1,1) PRIMARY KEY,
	LanguageName VARCHAR(25) NOT NULL UNIQUE
);

--⦁	MovieLanguageId
--⦁	LanguageName

--MovieJoner
CREATE TABLE MovieJoner(
	MovieJonerId INT IDENTITY(1,1) PRIMARY KEY,
	JonerName VARCHAR(25) NOT NULL UNIQUE
);

--⦁	MovieJonerId
--⦁	JonerName

--Movies
CREATE TABLE Movies(
	MovieId INT IDENTITY(1,1) PRIMARY KEY,
	MovieName VARCHAR(25) NOT NULL,
	MovieJonerId INT,
	MovieLanguageId INT,
	CONSTRAINT FK_Movies_MovieJoner FOREIGN KEY (MovieJonerId) REFERENCES MovieJoner(MovieJonerId)
);
ALTER TABLE Movies 
	ADD CONSTRAINT FK_Movies_MovieLanguage FOREIGN KEY (MovieLanguageId) REFERENCES MovieLanguage(MovieLanguageId)
;

--⦁	MovieId
--⦁	MovieName
--⦁	MovieJonerId
--⦁	MovieLanguageId

--Theater
CREATE TABLE Theater(
	TheaterId INT PRIMARY KEY IDENTITY(1,1),
	TheaterName VARCHAR(25) UNIQUE NOT NULL,
	City VARCHAR(25) NOT NULL,
	Address VARCHAR(225) NOT NULL
);

--⦁	TheaterId
--⦁	TheaterName
--⦁	City
--⦁	Address

--Screen
CREATE TABLE Screen(
	ScreenId INT IDENTITY(1,1) PRIMARY KEY,
	ScreenName VARCHAR(25) NOT NULL,
	TheaterId INT,
	TotalSeats INT NOT NULL,
	CONSTRAINT FK_Screen_Theater  FOREIGN KEY (TheaterId) REFERENCES Theater(TheaterId)
);

--⦁	ScreenId
--⦁	ScreenName
--⦁	TheaterId
--⦁	TotalSeats

--Show
CREATE TABLE Show(
	ShowId INT IDENTITY(1,1) PRIMARY KEY,
	MovieId INT,
	ScreenId INT,
	ShowDate DATE,
	ShowTime DATETIME,
	Price DECIMAL(5,2),
	CONSTRAINT FK_Show_Movie  FOREIGN KEY (MovieId) REFERENCES Movies(MovieId),
	CONSTRAINT FK_Show_Screen  FOREIGN KEY (ScreenId) REFERENCES Screen(ScreenId)
);

--⦁	ShowId
--⦁	MovieId
--⦁	ScreenId
--⦁	ShowDate
--⦁	ShowTime
--⦁	Price

--SeatCategories
CREATE TABLE SeatCategories (
	SeatCategoryId INT IDENTITY(1,1) PRIMARY KEY,
	CategoryName VARCHAR(25) NOT NULL,
	PriceMultiplier DECIMAL(4,2) NOT NULL
);

--⦁	SeatCategoryId
--⦁	CategoryName
--⦁	PriceMultiplier

--Seat
CREATE TABLE Seat(
	SeatId INT IDENTITY(1,1) PRIMARY KEY,
	ScreenId INT NOT NULL,
	SeatNumber INT NOT NULL,
	SeatCategoryId INT,
	CONSTRAINT FK_Seat_SeatCategies FOREIGN KEY (SeatCategoryId) REFERENCES SeatCategories(SeatCategoryId)
);
ALTER TABLE Seat ADD CONSTRAINT FK_Seat_Screen FOREIGN KEY (ScreenId) REFERENCES Screen(ScreenId)

--⦁	SeatId
--⦁	ScreenId
--⦁	SeatNumber
--⦁	SeatCategoryId



--Booking
CREATE TABLE Booking ( 
	BookingId INT IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL,
	ShowId INT NOT NULL,
	BookingDate DATE,
	TotalAmount DECIMAL(7,2),
	PaymentStatus VARCHAR(10) CHECK (PaymentStatus IN ('Paid', 'Pending', 'Failed')),
	CONSTRAINT FK_Booking_User FOREIGN KEY (UserId) REFERENCES Users(UserId),
	CONSTRAINT FK_Booking_Show FOREIGN KEY (ShowId) REFERENCES Show(ShowId)
);

--⦁	BookingId
--⦁	UserId
--⦁	ShowId
--⦁	BookingDate
--⦁	TotalAmount
--⦁	PaymentStatus

--BookedSeat
CREATE TABLE BookedSeat(
	BookedSeatId INT IDENTITY(1,1) PRIMARY KEY,
	BookingId INT NOT NULL,
	SeatId INT NOT NULL,
	CONSTRAINT FK_BookedSeat_Booking FOREIGN KEY (BookingId) REFERENCES Booking(BookingId),
	CONSTRAINT FK_BookedSeat_Seat FOREIGN KEY (SeatId) REFERENCES Seat(SeatId),
);

--⦁	BookedSeatId
--⦁	BookingId
--⦁	SeatId


--INSERT


INSERT INTO Users (Name, Email, Phone) VALUES
('Nabeel', 'nabeel@gmail.com', '9876543210'),
('Shahul Hamid', 'shahul@gmail.com', '6543210987');


INSERT INTO MovieLanguage (LanguageName) VALUES
('Hindi'),
('English'),
('Tamil'),
('Telugu');


INSERT INTO MovieJoner (JonerName) VALUES
('Action'),
('Comedy'),
('Romance'),
('Thriller');


INSERT INTO Movies (MovieName, MovieJonerId, MovieLanguageId) VALUES
('Thudarum', 1, 1),
('Lokha', 1, 1),
('The Marvels', 1, 2),
('Love Today', 3, 3),
('Dude', 1, 4);


INSERT INTO Theater (TheaterName, City, Address) VALUES
('PVR Cinemas', 'Trivandrum', 'LuLu Mall TVM'),
('SAVITHA Film City', 'Kannur', 'Caltex Road , Kannur'),
('Cinepolis', 'Kannur', 'Secure Center, Thazhechovva'),
('Carnival Cinemas', 'Kochi', 'Kerala');


INSERT INTO Screen (ScreenName, TheaterId, TotalSeats) VALUES
('Screen 1', 1, 100),
('Screen 2', 1, 120),
('Screen 1', 2, 80),
('Screen 1', 3, 90),
('Screen 2', 4, 150);


INSERT INTO [Show] (MovieId, ScreenId, ShowDate, ShowTime, Price) VALUES
(1, 1, '2025-10-28', '2025-10-28 10:00:00', 250.00),
(2, 2, '2025-10-28', '2025-10-28 14:00:00', 300.00),
(3, 3, '2025-10-28', '2025-10-28 18:00:00', 350.00),
(4, 4, '2025-10-28', '2025-10-28 20:00:00', 200.00);


INSERT INTO SeatCategories (CategoryName, PriceMultiplier) VALUES
('Regular', 1.00),
('Premium', 1.25),
('VIP', 1.50);


INSERT INTO Seat (ScreenId, SeatNumber, SeatCategoryId) VALUES
(1, 1, 1),
(1, 2, 1),
(1, 3, 2),
(2, 1, 1),
(2, 2, 3),
(3, 1, 1),
(4, 1, 2),
(5, 1, 3);


INSERT INTO Booking (UserId, ShowId, BookingDate, TotalAmount, PaymentStatus) VALUES
(1, 1, '2025-10-27', 500.00, 'Paid'),
(2, 2, '2025-10-27', 300.00, 'Pending')


INSERT INTO BookedSeat (BookingId, SeatId) VALUES
(4, 1),
(4, 2),
(5, 4),
(5, 6);

