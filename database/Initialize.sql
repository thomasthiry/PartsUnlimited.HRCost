CREATE TABLE EMPLOYEE (
   ID 			        INT IDENTITY(1,1) PRIMARY KEY     NOT NULL,
   REFERENCE            INT                     NOT NULL,
   LASTNAME             VARCHAR(255)            NOT NULL,
   FIRSTNAME            VARCHAR(255)            NOT NULL,
   DATEOFBIRTH          DATE,
   ADDRESSNUMBER        VARCHAR(255),
   ADDRESSSTREET        VARCHAR(255),
   ADDRESSCITY          VARCHAR(255),
   ADDRESSPOSTALCODE    VARCHAR(50),
   ADDRESSCOUNTRY       VARCHAR(255),
   JOINEDCOMPANYDATE    DATE,
   GROSSMONTHLYSALARY   DECIMAL(19,4), -- Use DECIMAL for money values
   HASCELLPHONEPLAN     BIT,
   NBDAYSYEARLYHOLIDAYS INT,
   HASDOUBLEHOLIDAYPREMIUM BIT,
   HASENDOFYEARPREMIUM  BIT
);

-- INSERT INTO employee
-- (reference, lastname, firstname, dateofbirth, addressnumber, addressstreet, addresscity, addresspostalcode, addresscountry, joinedcompanydate, grossmonthlysalary, HASCELLPHONEPLAN, nbdaysyearlyholidays)
-- VALUES(1, 'Cooper', 'Dale', '1959-02-22', '54', 'Trees street', 'Yakima, Washington', '98908', 'USA', '2015-03-18', 3000, 0, 20);