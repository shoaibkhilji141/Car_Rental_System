-- Create the database and use it
CREATE DATABASE dbSigned_Up;
USE dbSigned_Up;

-- Create the Persons table
CREATE TABLE Persons (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) UNIQUE, -- Ensure Username is unique
    Password VARCHAR(40),
    Gender VARCHAR(10),
    Contact VARCHAR(50)
);

-- Create the Cars table
CREATE TABLE Cars (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Car_ID VARCHAR(50) UNIQUE, -- Ensure Car_ID is unique
    Make VARCHAR(50),
    Model VARCHAR(50),
    Price INT,
    Year DATE,
    Availability BIT DEFAULT 1
);


-- Create the Rental_Record table
CREATE TABLE Rental_Record (
    Rental_ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Unique identifier for each rental record
    User_ID VARCHAR(50) NOT NULL, -- Foreign key referencing Persons
    Car_ID VARCHAR(50) NOT NULL,
	REntal_Hours int NOT NULL,-- Foreign key referencing Cars
    Total_Price INT, -- Total price for the rental
    Rental_Date DATETIME DEFAULT GETDATE(),
	Return_Date DATETIME,-- Timestamp for the rental
);

-- Verify the structure of the Rental_Record table
SELECT * FROM Rental_Record;


-- Insert data into Cars
INSERT INTO Cars (Car_ID, Make, Model, Price, Year) VALUES
('C001', 'Toyota', 'Corolla', 20000, '2020-01-01'),
('C002', 'Honda', 'Civic', 22000, '2019-05-10'),
('C003', 'Ford', 'Focus', 18000, '2018-08-15'),
('C004', 'Chevrolet', 'Malibu', 25000, '2021-03-22'),
('C005', 'Tesla', 'Model 3', 35000, '2022-07-18'),
('C006', 'BMW', '3 Series', 40000, '2021-11-30'),
('C007', 'Mercedes-Benz', 'C-Class', 42000, '2020-12-01'),
('C008', 'Audi', 'A4', 38000, '2019-09-12'),
('C009', 'Hyundai', 'Elantra', 19000, '2020-04-05'),
('C010', 'Kia', 'Optima', 21000, '2019-06-20');

-- Insert data into Persons
INSERT INTO Persons (Username, Password, Gender, Contact) VALUES
('john doe', 'pass123', 'Male', 'john@example.com'),
('jane_doe', 'pass456', 'Female', 'jane@example.com'),
('alex_smith', 'pass789', 'Male', 'alex@example.com'),
('lisa_wong', 'pass101', 'Female', 'lisa@example.com'),
('michael_clark', 'pass202', 'Male', 'michael@example.com'),
('sara_lee', 'pass303', 'Female', 'sara@example.com'),
('daniel_james', 'pass404', 'Male', 'daniel@example.com'),
('emma_jones', 'pass505', 'Female', 'emma@example.com'),
('oliver_turner', 'pass606', 'Male', 'oliver@example.com'),
('isabella_king', 'pass707', 'Female', 'isabella@example.com');

-- Verify tables
SELECT * FROM Cars;
SELECT * FROM Persons;
SELECT * FROM FEEDBACK;
SELECT * FROM LoggedIn;
Select * From Rental_Record;
CREATE TABLE LoggedIn (
 ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50), -- Ensure Username is unique
);
CREATE TABLE FEEDBACK (
    Username VARCHAR(50) NOT NULL UNIQUE,
    Feedback VARCHAR(MAX) NOT NULL
);

INSERT INTO LoggedIn(Username) VALUES
('john doe'),
('jane_doe'),
('alex_smith');
