-- ROLE Table
CREATE TABLE Role_ (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  RoleName VARCHAR2(50),
  
  Constraint UQ_ROLE_ROLENAME UNIQUE (RoleName)
);

-- USER Table
CREATE TABLE User_ (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  Username VARCHAR2(50),
  Password VARCHAR2(50),
  Email VARCHAR2(100),
  VerfiicationCode VARCHAR2(50),
  UserStatus VARCHAR2(20),
  RoleId NUMBER,
  
  Constraint UQ_USER_USERNAME UNIQUE (Username),
  Constraint UQ_USER_EMAIL UNIQUE (Email),
  Constraint FK_USER_ROLEID FOREIGN KEY (RoleId) REFERENCES Role_(ID) ON DELETE CASCADE
);

-- PROFILE Table
CREATE TABLE Profile (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  FirstName VARCHAR2(50),
  LastName VARCHAR2(50),
  ImagePath VARCHAR2(100),
  PhoneNumber NUMBER,
  Gender VARCHAR2(10),
  DateOfBirth DATE,
  Bio VARCHAR2(500),
  Rate NUMBER,
  UserId NUMBER,
  
  Constraint UQ_PROFILE_PHONENUMBER UNIQUE (PhoneNumber),
  Constraint FK_PROFILE_USERID FOREIGN KEY (UserId) REFERENCES User_(ID) ON DELETE CASCADE
);

-- PROFILESETTING Table
CREATE TABLE ProfileSetting (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  Language VARCHAR2(50),
  Theme VARCHAR2(50),
  ProfileId NUMBER,
  
  Constraint FK_PROFILESETTING_PROFILEID FOREIGN KEY (ProfileId) REFERENCES Profile(ID) ON DELETE CASCADE
);

-- NOTIFICATION Table
CREATE TABLE Notification (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  Content VARCHAR2(500),
  ReceivedDate DATE,
  ReceiverId NUMBER,
  
  Constraint FK_NOTIFICATION_RECEIVERID FOREIGN KEY (ReceiverId) REFERENCES User_(ID) ON DELETE CASCADE
);

-- PAGE Table
CREATE TABLE Page (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  Content1 VARCHAR2(500),
  Content2 VARCHAR2(500),
  BackgroundImagePath VARCHAR2(100),
  AdminId NUMBER,
  
  Constraint FK_PAGE_ADMINID FOREIGN KEY (AdminId) REFERENCES User_(ID) ON DELETE CASCADE
);

-- TESTIMONIAL Table
CREATE TABLE Testimonial (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  Content VARCHAR2(500),
  CreationDate DATE,
  Status VARCHAR2(20),
  UserId NUMBER,
  
  Constraint FK_TESTIMONIAL_USERID FOREIGN KEY (UserId) REFERENCES User_(ID) ON DELETE CASCADE
);

-- CATEGORY Table
CREATE TABLE Category (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  Name VARCHAR2(50),
  ImagePath VARCHAR2(100),
  Description VARCHAR2(500),
  CreationDate DATE,
  AdminId NUMBER,
  
  Constraint FK_CATEGORY_ADMINID FOREIGN KEY (AdminId) REFERENCES User_(ID) ON DELETE CASCADE
);

-- EVENT Table
CREATE TABLE Event (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  Name VARCHAR2(100),
  AttendingCost FLOAT,
  StartDate DATE,
  EndDate DATE,
  Status VARCHAR2(20),
  EventDescription VARCHAR2(500),
  ImagePath VARCHAR2(100),
  EventCapacity NUMBER,
  Latitude NUMBER,
  Longitude NUMBER,
  EventCreatorId NUMBER,
  CategoryId NUMBER,
  
  Constraint FK_EVENT_CREATORID FOREIGN KEY (EventCreatorId) REFERENCES User_(ID) ON DELETE CASCADE,
  Constraint FK_EVENT_CATEGORYID FOREIGN KEY (CategoryId) REFERENCES Category(ID) ON DELETE CASCADE
);

create table comments(
    ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    Content VARCHAR2(500),
    EventId NUMBER,
    
    Constraint FK_COMMENT_EVENTID FOREIGN KEY (EventId) REFERENCES Event(ID) ON DELETE CASCADE
)

-- BOOKING Table
CREATE TABLE Booking (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  BookingDate DATE,
  UserId NUMBER,
  EventId NUMBER,
  
  Constraint FK_BOOKING_USERID FOREIGN KEY (UserId) REFERENCES User_(ID) ON DELETE CASCADE,
  Constraint FK_BOOKING_EVENTID FOREIGN KEY (EventId) REFERENCES Event(ID) ON DELETE CASCADE
);

-- BANK Table
CREATE TABLE Bank (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  CardNumber VARCHAR2(20),
  CardHolder VARCHAR2(100),
  ExpirationDate DATE,
  CVV VARCHAR2(10),
  Balance NUMBER,
  
  Constraint UQ_BANK_CARDNUMBER UNIQUE (CardNumber)
);

-- PAYMENT Table
CREATE TABLE Payment (
  ID NUMBER,
  PaymentDate DATE,
  Amount FLOAT,
  Method VARCHAR2(50),
  Status VARCHAR2(20),
  UserId NUMBER,
  
  Constraint FK_PAYMENT_USERID FOREIGN KEY (UserId) REFERENCES User_(ID) ON DELETE CASCADE
);

-- MESSAGE Table
CREATE TABLE Message (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  Content VARCHAR2(500),
  MessageDate DATE,
  IsRead NUMBER(1),
  IsDeleted NUMBER(1),
  SenderId NUMBER,
  ReceiverId NUMBER,
  
  Constraint FK_MESSAGE_SENDERID FOREIGN KEY (SenderId) REFERENCES User_(ID) ON DELETE CASCADE,
  Constraint FK_MESSAGE_RECEIVERID FOREIGN KEY (ReceiverId) REFERENCES User_(ID) ON DELETE CASCADE
);

-- CONTACT Table
CREATE TABLE Contact_Us_Entries (
  ID NUMBER GENERATED BY DEFAULT AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
  Subject VARCHAR2(100),
  Content VARCHAR2(500),
  Email VARCHAR2(100),
  PhoneNumber NUMBER
--  PhoneNumber Varchar2(13)
);

--insert into Role_(ROLENAME) Values('Admin');
--insert into Role_(ROLENAME) Values('User');
--insert into Role_(ROLENAME) Values('Guest');

--INSERT INTO User_ (Username, Password, Email, VerfiicationCode, UserStatus, RoleId)
--VALUES ('Admin', 'AdminPass', 'Admin@example.com', 'verification_code', 'active', 1);

--INSERT INTO User_ (Username, Password, Email, VerfiicationCode, UserStatus, RoleId)
--VALUES ('TestUser', 'UserPass', 'User1@example.com', 'verification_code', 'active', 2);


commit;

select * from Role_;
select * from User_;

select * from User_ u
join Role_ r on u.RoleId = r.ID;

--drop table comments;
--drop table Contact_Us_Entries
--drop table Message;
--drop table Payment;
--drop table Bank;
--drop table Booking;
--drop table Event;
--drop table Category;
--drop table Testimonial;
--drop table Page;
--drop table Notification;
--drop table ProfileSetting;
--drop table Profile;
--drop table User_;
--drop table Role_;


-- USER PACKAGE
CREATE OR REPLACE PACKAGE User_Package AS
  -- Procedure to get all users
  PROCEDURE GetAllUsers;

  -- Procedure to get a user by ID
  PROCEDURE GetUserByID(p_UserID IN NUMBER);
  
  PROCEDURE GetUserByUserName(User_Name IN VARCHAR2);

  -- Procedure to delete a user by ID
  PROCEDURE DeleteUserByID(p_UserID IN NUMBER);

  -- Procedure to update a user by ID
  PROCEDURE UpdateUserByID(p_UserID IN NUMBER, p_Username IN VARCHAR2, p_Password IN VARCHAR2, p_Email IN VARCHAR2, p_VerificationCode IN VARCHAR2, p_UserStatus IN VARCHAR2, p_RoleID IN NUMBER);

  -- Procedure to create a new user
  PROCEDURE CreateUser(p_Username IN VARCHAR2, p_Password IN VARCHAR2, p_Email IN VARCHAR2, p_VerificationCode IN VARCHAR2, p_UserStatus IN VARCHAR2, p_RoleID IN NUMBER);
END User_Package;

-- USER PACKAGE BODY
CREATE OR REPLACE PACKAGE BODY User_Package AS
  -- Procedure to get all users
  PROCEDURE GetAllUsers AS
    cur_all SYS_REFCURSOR;
  BEGIN
    OPEN cur_all FOR 'SELECT * FROM User_';
    DBMS_SQL.RETURN_RESULT(cur_all);
  END;

  -- Procedure to get a user by ID
  PROCEDURE GetUserByID(p_UserID IN NUMBER) AS
    cur_item SYS_REFCURSOR;
  BEGIN
    OPEN cur_item FOR 'SELECT * FROM User_ WHERE ID = :id' USING p_UserID;
    DBMS_SQL.RETURN_RESULT(cur_item);
  END;

  PROCEDURE GetUserByUserName(User_Name IN VARCHAR2)
  As
    cur_item SYS_REFCURSOR;
  BEGIN
    OPEN cur_item FOR 'SELECT * FROM User_ WHERE Username = :user_name' USING User_Name;
    DBMS_SQL.RETURN_RESULT(cur_item);
  END;
  
  -- Procedure to delete a user by ID
  PROCEDURE DeleteUserByID(p_UserID IN NUMBER) AS
  BEGIN
    EXECUTE IMMEDIATE 'DELETE FROM User_ WHERE ID = :id' USING p_UserID;
  END;

  -- Procedure to update a user by ID
  PROCEDURE UpdateUserByID(p_UserID IN NUMBER, p_Username IN VARCHAR2, p_Password IN VARCHAR2, p_Email IN VARCHAR2, p_VerificationCode IN VARCHAR2, p_UserStatus IN VARCHAR2, p_RoleID IN NUMBER) AS
  BEGIN
    EXECUTE IMMEDIATE 'UPDATE User_ SET Username = :username, Password = :password, Email = :email, VerfiicationCode = :verificationcode, UserStatus = :userstatus, RoleID = :roleid WHERE ID = :id'
      USING p_Username, p_Password, p_Email, p_VerificationCode, p_UserStatus, p_RoleID, p_UserID;
  END;

  -- Procedure to create a new user
  PROCEDURE CreateUser(p_Username IN VARCHAR2, p_Password IN VARCHAR2, p_Email IN VARCHAR2, p_VerificationCode IN VARCHAR2, p_UserStatus IN VARCHAR2, p_RoleID IN NUMBER) AS
  BEGIN
    EXECUTE IMMEDIATE 'INSERT INTO User_ (Username, Password, Email, VerfiicationCode, UserStatus, RoleID) VALUES (:username, :password, :email, :verificationcode, :userstatus, :roleid)'
      USING p_Username, p_Password, p_Email, p_VerificationCode, p_UserStatus, p_RoleID;
  END;
  
END User_Package;


-- EVENT PACKAGE
CREATE OR REPLACE PACKAGE Event_Package AS
  -- Procedure to get all events
  PROCEDURE GetAllEvents;

  -- Procedure to get an event by ID
  PROCEDURE GetEventByID(p_EventID IN NUMBER);

  -- Procedure to delete an event by ID
  PROCEDURE DeleteEventByID(p_EventID IN NUMBER);

  -- Procedure to update an event by ID
  PROCEDURE UpdateEventByID(p_EventID IN NUMBER, p_Name IN VARCHAR2, p_AttendingCost IN FLOAT, p_StartDate IN DATE, p_EndDate IN DATE, p_Status IN VARCHAR2, p_EventDescription IN VARCHAR2, p_ImagePath IN VARCHAR2, p_EventCapacity IN NUMBER, p_Latitude IN NUMBER, p_Longitude IN NUMBER, p_EventCreatorID IN NUMBER, p_CategoryID IN NUMBER);

  -- Procedure to create a new event
  PROCEDURE CreateEvent(p_Name IN VARCHAR2, p_AttendingCost IN FLOAT, p_StartDate IN DATE, p_EndDate IN DATE, p_Status IN VARCHAR2, p_EventDescription IN VARCHAR2, p_ImagePath IN VARCHAR2, p_EventCapacity IN NUMBER, p_Latitude IN NUMBER, p_Longitude IN NUMBER, p_EventCreatorID IN NUMBER, p_CategoryID IN NUMBER);
END Event_Package;

-- EVENT PACKAGE BODY
CREATE OR REPLACE PACKAGE BODY Event_Package AS
  -- Procedure to get all events
  PROCEDURE GetAllEvents AS
    cur_all SYS_REFCURSOR;
  BEGIN
    OPEN cur_all FOR 'SELECT * FROM Event';
    DBMS_SQL.RETURN_RESULT(cur_all);
  END;

  -- Procedure to get an event by ID
  PROCEDURE GetEventByID(p_EventID IN NUMBER) AS
    cur_item SYS_REFCURSOR;
  BEGIN
    OPEN cur_item FOR 'SELECT * FROM Event WHERE ID = :id' USING p_EventID;
    DBMS_SQL.RETURN_RESULT(cur_item);
  END;

  -- Procedure to delete an event by ID
  PROCEDURE DeleteEventByID(p_EventID IN NUMBER) AS
  BEGIN
    EXECUTE IMMEDIATE 'DELETE FROM Event WHERE ID = :id' USING p_EventID;
  END;

  -- Procedure to update an event by ID
  PROCEDURE UpdateEventByID(p_EventID IN NUMBER, p_Name IN VARCHAR2, p_AttendingCost IN FLOAT, p_StartDate IN DATE, p_EndDate IN DATE, p_Status IN VARCHAR2, p_EventDescription IN VARCHAR2, p_ImagePath IN VARCHAR2, p_EventCapacity IN NUMBER, p_Latitude IN NUMBER, p_Longitude IN NUMBER, p_EventCreatorID IN NUMBER, p_CategoryID IN NUMBER) AS
  BEGIN
    EXECUTE IMMEDIATE 'UPDATE Event SET Name = :name, AttendingCost = :attendingcost, StartDate = :startdate, EndDate = :enddate, Status = :status, EventDescription = :eventdescription, ImagePath = :imagepath, EventCapacity = :eventcapacity, Latitude = :latitude, Longitude = :longitude, EventCreatorID = :eventcreatorid, CategoryID = :categoryid WHERE ID = :id'
      USING p_Name, p_AttendingCost, p_StartDate, p_EndDate, p_Status, p_EventDescription, p_ImagePath, p_EventCapacity, p_Latitude, p_Longitude, p_EventCreatorID, p_CategoryID, p_EventID;
  END;

  -- Procedure to create a new event
  PROCEDURE CreateEvent(p_Name IN VARCHAR2, p_AttendingCost IN FLOAT, p_StartDate IN DATE, p_EndDate IN DATE, p_Status IN VARCHAR2, p_EventDescription IN VARCHAR2, p_ImagePath IN VARCHAR2, p_EventCapacity IN NUMBER, p_Latitude IN NUMBER, p_Longitude IN NUMBER, p_EventCreatorID IN NUMBER, p_CategoryID IN NUMBER) AS
  BEGIN
    EXECUTE IMMEDIATE 'INSERT INTO Event (Name, AttendingCost, StartDate, EndDate, Status, EventDescription, ImagePath, EventCapacity, Latitude, Longitude, EventCreatorID, CategoryID) VALUES (:name, :attendingcost, :startdate, :enddate, :status, :eventdescription, :imagepath, :eventcapacity, :latitude, :longitude, :eventcreatorid, :categoryid)'
      USING p_Name, p_AttendingCost, p_StartDate, p_EndDate, p_Status, p_EventDescription, p_ImagePath, p_EventCapacity, p_Latitude, p_Longitude, p_EventCreatorID, p_CategoryID;
  END;
  
END Event_Package;


-- CATEGORY PACKAGE
CREATE OR REPLACE PACKAGE CATEGORY_PACKAGE
AS
    PROCEDURE GetAllCategories;
    PROCEDURE GetCategoryById(CATEGORY_ID IN NUMBER);
    PROCEDURE CreateCategory(NAME_ IN VARCHAR2, IMAGE_PATH IN VARCHAR2, DESCRIPTION_ IN VARCHAR2, CREATION_DATE IN DATE, ADMIN_ID NUMBER);
    PROCEDURE UpdateCategory(CATEGORY_ID IN NUMBER, NAME_ IN VARCHAR2, IMAGE_PATH IN VARCHAR2, DESCRIPTION_ IN VARCHAR2, CREATION_DATE IN DATE, ADMIN_ID NUMBER);
    PROCEDURE DeleteCategory(CATEGORY_ID IN NUMBER);
    
END CATEGORY_PACKAGE;

-- CATEGORY PACKAGE BODY
CREATE OR REPLACE PACKAGE BODY CATEGORY_PACKAGE
AS
    PROCEDURE GetAllCategories
    AS
        cur_all SYS_REFCURSOR;
        BEGIN
        open cur_all for
        select * from category;
        Dbms_sql.return_result(cur_all);
    END GetAllCategories;
    
    PROCEDURE getCategoryById(CATEGORY_ID IN NUMBER)
    AS
        cur_item SYS_REFCURSOR;
        BEGIN
        open cur_item for
        select * from category
        where id = CATEGORY_ID;
        Dbms_sql.return_result(cur_item);
    
    END getCategoryById;
    
    PROCEDURE CreateCategory(NAME_ IN VARCHAR2, IMAGE_PATH IN VARCHAR2, DESCRIPTION_ IN VARCHAR2, CREATION_DATE IN DATE, ADMIN_ID NUMBER)
    AS
        id number;
        BEGIN
        INSERT INTO CATEGORY(NAME, IMAGEPATH, DESCRIPTION, CREATIONDATE, ADMINID) VALUES (NAME_, IMAGE_PATH, DESCRIPTION_, CREATION_DATE, ADMIN_ID);
        COMMIT;
    
    END CreateCategory;
    
    PROCEDURE UpdateCategory(CATEGORY_ID IN NUMBER, NAME_ IN VARCHAR2, IMAGE_PATH IN VARCHAR2, DESCRIPTION_ IN VARCHAR2, CREATION_DATE IN DATE, ADMIN_ID NUMBER)
    AS
        BEGIN
        UPDATE CATEGORY
        SET NAME=NAME_, IMAGEPATH=IMAGE_PATH, DESCRIPTION=DESCRIPTION_, CREATIONDATE=CREATION_DATE, ADMINID=ADMIN_ID
        WHERE ID = CATEGORY_ID;
        COMMIT;
    
    END UpdateCategory;
    
    PROCEDURE DeleteCategory(CATEGORY_ID IN NUMBER)
        As
        BEGIN
        delete from CATEGORY
        where ID = CATEGORY_ID;
        commit;
    
    END DeleteCategory;

END CATEGORY_PACKAGE;


-- PAGE PACKAGE
CREATE OR REPLACE PACKAGE Page_Package
AS
    PROCEDURE GetAllPages;
    PROCEDURE GetPageById(PAGE_ID IN NUMBER);
    PROCEDURE CreatePage(CONTENT_1 IN VARCHAR2, CONTENT_2 IN VARCHAR2, IMAGEPATH IN VARCHAR2, ADMIN_ID IN NUMBER);
    PROCEDURE UpdatePage(PAGE_ID IN NUMBER, CONTENT_1 IN VARCHAR2, CONTENT_2 IN VARCHAR2, IMAGEPATH IN VARCHAR2, ADMIN_ID IN NUMBER);
    PROCEDURE DeletePage(PAGE_ID IN NUMBER);
    
END Page_Package;

-- PAGE PACKAGE BODY
CREATE OR REPLACE PACKAGE BODY Page_Package
AS
    PROCEDURE GetAllPages
    AS
        cur_all SYS_REFCURSOR;
        BEGIN
        open cur_all for
        select * from Page;
        Dbms_sql.return_result(cur_all);
    END GetAllPages;
    
    PROCEDURE GetPageById(PAGE_ID IN NUMBER)
    AS
        cur_item SYS_REFCURSOR;
        BEGIN
        open cur_item for
        select * from PAGE
        where id = PAGE_ID;
        Dbms_sql.return_result(cur_item); 
    END GetPageById;
       
    PROCEDURE CreatePage(CONTENT_1 IN VARCHAR2, CONTENT_2 IN VARCHAR2, IMAGEPATH IN VARCHAR2, ADMIN_ID IN NUMBER)
    AS
        ID NUMBER;
        BEGIN
        INSERT INTO PAGE(CONTENT1, CONTENT2, BackgroundImagePath, ADMINID) VALUES (CONTENT_1, CONTENT_2, IMAGEPATH, ADMIN_ID);
        COMMIT;
    END CreatePage;
    
    PROCEDURE UpdatePage(PAGE_ID IN NUMBER, CONTENT_1 IN VARCHAR2, CONTENT_2 IN VARCHAR2, IMAGEPATH IN VARCHAR2, ADMIN_ID IN NUMBER)
    AS
        BEGIN
        UPDATE PAGE
        SET CONTENT1=CONTENT_1, CONTENT2=CONTENT_2, BackgroundImagePath=IMAGEPATH, ADMINID=ADMIN_ID
        WHERE ID=PAGE_ID;
        COMMIT;
    END UpdatePage;
    
    PROCEDURE DeletePage(PAGE_ID IN NUMBER)
    AS 
        BEGIN
        DELETE from PAGE
        WHERE ID = PAGE_ID;
        COMMIT;
    END DeletePage;
    
END Page_Package;


-- PROFILE PACKAGE
CREATE OR REPLACE PACKAGE Profile_Package AS
  -- Procedure to get all profiles
  PROCEDURE GetAllProfiles;
  
  -- Procedure to get a profile by ID
  PROCEDURE GetProfileByID(p_ProfileID IN NUMBER);
  
  -- Procedure to delete a profile by ID
  PROCEDURE DeleteProfileByID(p_ProfileID IN NUMBER);
  
  -- Procedure to update a profile by ID
  PROCEDURE UpdateProfileByID(p_ProfileID IN NUMBER, p_FirstName IN VARCHAR2, p_LastName IN VARCHAR2, p_ImagePath IN VARCHAR2, p_PhoneNumber IN NUMBER, p_Gender IN VARCHAR2, p_DateOfBirth IN DATE, p_Bio IN VARCHAR2, p_Rate IN NUMBER, p_UserID IN NUMBER);
  
  -- Procedure to create a new profile
  PROCEDURE CreateProfile(p_FirstName IN VARCHAR2, p_LastName IN VARCHAR2, p_ImagePath IN VARCHAR2, p_PhoneNumber IN NUMBER, p_Gender IN VARCHAR2, p_DateOfBirth IN DATE, p_Bio IN VARCHAR2, p_Rate IN NUMBER, p_UserID IN NUMBER);
END Profile_Package;

-- PROFILE PACKAGE BODY
CREATE OR REPLACE PACKAGE BODY Profile_Package AS
  -- Procedure to get all profiles
  PROCEDURE GetAllProfiles AS
    cur_all SYS_REFCURSOR;
  BEGIN
    OPEN cur_all FOR 'SELECT * FROM Profile';
    DBMS_SQL.RETURN_RESULT(cur_all);
  END;
  
  -- Procedure to get a profile by ID
  PROCEDURE GetProfileByID(p_ProfileID IN NUMBER) AS
    cur_item SYS_REFCURSOR;
  BEGIN
    OPEN cur_item FOR 'SELECT * FROM Profile WHERE ID = :id' USING p_ProfileID;
    DBMS_SQL.RETURN_RESULT(cur_item);
  END;
  
  -- Procedure to delete a profile by ID
  PROCEDURE DeleteProfileByID(p_ProfileID IN NUMBER) AS
  BEGIN
    DELETE FROM Profile WHERE ID = p_ProfileID;
  END;
  
  -- Procedure to update a profile by ID
  PROCEDURE UpdateProfileByID(p_ProfileID IN NUMBER, p_FirstName IN VARCHAR2, p_LastName IN VARCHAR2, p_ImagePath IN VARCHAR2, p_PhoneNumber IN NUMBER, p_Gender IN VARCHAR2, p_DateOfBirth IN DATE, p_Bio IN VARCHAR2, p_Rate IN NUMBER, p_UserID IN NUMBER) AS
  BEGIN
    UPDATE Profile SET
      FirstName = p_FirstName,
      LastName = p_LastName,
      ImagePath = p_ImagePath,
      PhoneNumber = p_PhoneNumber,
      Gender = p_Gender,
      DateOfBirth = p_DateOfBirth,
      Bio = p_Bio,
      Rate = p_Rate,
      UserID = p_UserID
    WHERE ID = p_ProfileID;
  END;
  
  -- Procedure to create a new profile
  PROCEDURE CreateProfile(p_FirstName IN VARCHAR2, p_LastName IN VARCHAR2, p_ImagePath IN VARCHAR2, p_PhoneNumber IN NUMBER, p_Gender IN VARCHAR2, p_DateOfBirth IN DATE, p_Bio IN VARCHAR2, p_Rate IN NUMBER, p_UserID IN NUMBER) AS
  BEGIN
    INSERT INTO Profile (FirstName, LastName, ImagePath, PhoneNumber, Gender, DateOfBirth, Bio, Rate, UserID)
    VALUES (p_FirstName, p_LastName, p_ImagePath, p_PhoneNumber, p_Gender, p_DateOfBirth, p_Bio, p_Rate, p_UserID);
  END;
  
END Profile_Package;


-- TESTIMONIAL PACKAGE
CREATE OR REPLACE PACKAGE Testimonial_Package AS
  -- Procedure to get all testimonials
  PROCEDURE GetAllTestimonials;
  
  -- Procedure to get a testimonial by ID
  PROCEDURE GetTestimonialByID(p_TestimonialID IN NUMBER);
  
  -- Procedure to delete a testimonial by ID
  PROCEDURE DeleteTestimonialByID(p_TestimonialID IN NUMBER);
  
  -- Procedure to update a testimonial by ID
  PROCEDURE UpdateTestimonialByID(p_TestimonialID IN NUMBER, p_Content IN VARCHAR2, p_CreationDate IN DATE, p_Status IN VARCHAR2, p_UserID IN NUMBER);
  
  -- Procedure to create a new testimonial
  PROCEDURE CreateTestimonial(p_Content IN VARCHAR2, p_CreationDate IN DATE, p_Status IN VARCHAR2, p_UserID IN NUMBER);
END Testimonial_Package;

-- TESTIMONIAL PACKAGE BODY
CREATE OR REPLACE PACKAGE BODY Testimonial_Package AS
  -- Procedure to get all testimonials
  PROCEDURE GetAllTestimonials AS
    cur_all SYS_REFCURSOR;
  BEGIN
    OPEN cur_all FOR 'SELECT * FROM Testimonial';
    DBMS_SQL.RETURN_RESULT(cur_all);
  END;
  
  -- Procedure to get a testimonial by ID
  PROCEDURE GetTestimonialByID(p_TestimonialID IN NUMBER) AS
    cur_item SYS_REFCURSOR;
  BEGIN
    OPEN cur_item FOR 'SELECT * FROM Testimonial WHERE ID = :id' USING p_TestimonialID;
    DBMS_SQL.RETURN_RESULT(cur_item);
  END;
  
  -- Procedure to delete a testimonial by ID
  PROCEDURE DeleteTestimonialByID(p_TestimonialID IN NUMBER) AS
  BEGIN
    DELETE FROM Testimonial WHERE ID = p_TestimonialID;
  END;
  
  -- Procedure to update a testimonial by ID
  PROCEDURE UpdateTestimonialByID(p_TestimonialID IN NUMBER, p_Content IN VARCHAR2, p_CreationDate IN DATE, p_Status IN VARCHAR2, p_UserID IN NUMBER) AS
  BEGIN
    UPDATE Testimonial SET
      Content = p_Content,
      CreationDate = p_CreationDate,
      Status = p_Status,
      UserID = p_UserID
    WHERE ID = p_TestimonialID;
  END;
  
  -- Procedure to create a new testimonial
  PROCEDURE CreateTestimonial(p_Content IN VARCHAR2, p_CreationDate IN DATE, p_Status IN VARCHAR2, p_UserID IN NUMBER) AS
  BEGIN
    INSERT INTO Testimonial (Content, CreationDate, Status, UserID)
    VALUES (p_Content, p_CreationDate, p_Status, p_UserID);
  END;
  
END Testimonial_Package;

-- BOOKING PACKAGE
CREATE OR REPLACE PACKAGE Booking_Package AS

    -- Create Procedure
    PROCEDURE CreateBooking(p_BookingDate IN Booking.BookingDate%TYPE, p_UserId IN Booking.UserId%TYPE, p_EventId IN Booking.EventId%TYPE, p_Is_successed OUT NUMBER);
    -- Read Procedure
    PROCEDURE GetBookingById(p_BookingId IN Booking.ID%TYPE);
    -- Update Procedure
    PROCEDURE UpdateBooking(p_BookingId IN Booking.ID%TYPE, p_BookingDate IN Booking.BookingDate%TYPE, p_UserId IN Booking.UserId%TYPE, p_EventId IN Booking.EventId%TYPE);
    -- Delete Procedure
    PROCEDURE DeleteBooking(p_BookingId IN Booking.ID%TYPE);
    -- Get All Procedures
    PROCEDURE GetAllBooking;

END Booking_Package;

CREATE OR REPLACE PACKAGE BODY Booking_Package AS

    -- Create Procedure
    PROCEDURE CreateBooking(p_BookingDate IN Booking.BookingDate%TYPE, p_UserId IN Booking.UserId%TYPE, p_EventId IN Booking.EventId%TYPE, p_Is_successed OUT NUMBER)
    AS
	Id NUMBER;
    	BEGIN
        	INSERT INTO Booking VALUES(DEFAULT, p_BookingDate, p_UserId, p_EventId) RETURNING ID INTO Id;
        	COMMIT;
		IF p_Is_successed IS NULL
		THEN
			p_Is_successed := 0;
		ELSE
			p_Is_successed := 1;
		END IF;
    END CreateBooking;

    -- Read Procedure
    PROCEDURE GetBookingById(p_BookingId IN Booking.ID%TYPE)
    AS
    	cur_item SYS_REFCURSOR;
        BEGIN
            OPEN cur_item FOR
                SELECT * FROM Booking
                WHERE ID = p_BookingId;
                Dbms_sql.return_result(cur_item);
    END GetBookingById;

    -- Update Procedure
    PROCEDURE UpdateBooking(p_BookingId IN Booking.ID%TYPE, p_BookingDate IN Booking.BookingDate%TYPE, p_UserId IN Booking.UserId%TYPE, p_EventId IN Booking.EventId%TYPE)
    AS
        BEGIN
            UPDATE Booking 
            SET BookingDate = p_BookingDate , UserId = p_UserId , EventId = p_EventId
            WHERE ID = p_BookingId ;
            COMMIT;
    END;

    -- Delete Procedure
    PROCEDURE DeleteBooking(p_BookingId IN Booking.ID%TYPE)
    AS
        BEGIN
            DELETE FROM Booking
            WHERE ID = p_BookingId;
            COMMIT;
    END;

    --GetAll Procedure
    PROCEDURE GetAllBooking
    AS
        cur_all SYS_REFCURSOR ;
        Begin 
            OPEN cur_all FOR
            SELECT * FROM Booking ;
            Dbms_sql.return_result(cur_all);
    END GetAllBooking;

END Booking_Package;


CREATE OR REPLACE PACKAGE Message_Package
AS
  
      -- Insert a new message
      PROCEDURE CreateMessage(p_Content IN Message.Content%TYPE, p_MessageDate IN Message.MessageDate%TYPE, p_IsRead IN Message.IsRead%TYPE, p_IsDeleted IN Message.IsDeleted%TYPE, p_SenderId IN Message.SenderId%TYPE, p_ReceiverId IN Message.ReceiverId%TYPE);
      -- Retrieve a message by ID
      PROCEDURE GetMessageById(p_Id IN Message.ID%TYPE) ;
      -- Update an existing message
      PROCEDURE UpdateMessage(p_Id IN Message.ID%TYPE, p_Content IN Message.Content%TYPE, p_MessageDate IN Message.MessageDate%TYPE, p_IsRead IN Message.IsRead%TYPE, p_IsDeleted IN Message.IsDeleted%TYPE, p_SenderId IN Message.SenderId%TYPE, p_ReceiverId IN Message.ReceiverId%TYPE);
      -- Delete a message
      PROCEDURE DeleteMessage(p_Id IN Message.ID%TYPE);
      -- Retrieve all messages
      PROCEDURE GetAllMessages;
  
END Message_Package;


CREATE OR REPLACE PACKAGE BODY Message_Package IS
  
      PROCEDURE CreateMessage(p_Content IN Message.Content%TYPE, p_MessageDate IN Message.MessageDate%TYPE, p_IsRead IN Message.IsRead%TYPE, p_IsDeleted IN Message.IsDeleted%TYPE, p_SenderId IN Message.SenderId%TYPE, p_ReceiverId IN Message.ReceiverId%TYPE)
    AS
        BEGIN
            INSERT INTO Message VALUES (DEFAULT,p_Content, p_MessageDate,p_IsRead, p_IsDeleted, p_SenderId, p_ReceiverId);
            COMMIT;
    END CreateMessage;
  
    PROCEDURE GetMessageById(p_Id IN Message.ID%TYPE)  
    AS
        cur_item SYS_REFCURSOR;
        BEGIN
            OPEN cur_item FOR
                SELECT * FROM Message
                WHERE ID = p_Id;
                Dbms_sql.return_result(cur_item);
    END GetMessageById;
  
    PROCEDURE UpdateMessage(p_Id IN Message.ID%TYPE, p_Content IN Message.Content%TYPE, p_MessageDate IN Message.MessageDate%TYPE, p_IsRead IN Message.IsRead%TYPE, p_IsDeleted IN Message.IsDeleted%TYPE, p_SenderId IN Message.SenderId%TYPE, p_ReceiverId IN Message.ReceiverId%TYPE)
    AS
        BEGIN
            UPDATE Message SET 
            Content = p_Content,
            MessageDate = p_MessageDate,
            IsRead = p_IsRead,
            IsDeleted = p_IsDeleted,
            SenderId = p_SenderId,
            ReceiverId = p_ReceiverId
            WHERE ID = p_Id;
            COMMIT;
    END UpdateMessage;
  
    PROCEDURE DeleteMessage(p_Id IN Message.ID%TYPE)
    AS
        BEGIN
            DELETE FROM Message WHERE ID = p_Id;
            COMMIT;
    END DeleteMessage;
  
    PROCEDURE GetAllMessages
    AS
        cur_all SYS_REFCURSOR ;
        Begin 
            OPEN cur_all FOR
                SELECT * FROM Message ;
                Dbms_sql.return_result(cur_all);
    END GetAllMessages;
  
END Message_Package;

-- Admin package
CREATE OR REPLACE PACKAGE Admin_Package
AS
    
    PROCEDURE EventAcceptation(p_event_id Event.ID%TYPE, p_event_status Event.Status%TYPE);
    
END Admin_Package;


CREATE OR REPLACE PACKAGE BODY Admin_Package
AS
    
    PROCEDURE EventAcceptation(p_event_id Event.ID%TYPE, p_event_status Event.Status%TYPE)
    AS
        BEGIN
        UPDATE Event SET Status = p_event_status
        WHERE ID = p_event_id;
        COMMIT;
    END EventAcceptation;
    
END Admin_Package;

-- Auth Package
create or replace PACKAGE Auth_Package 
AS
    PROCEDURE GetUser(User_Name IN VARCHAR2, PASS IN VARCHAR2);
END Auth_Package;

create or replace PACKAGE body Auth_Package 
AS
    PROCEDURE GetUser(User_Name IN VARCHAR2, PASS IN VARCHAR2)
    AS
        c_all SYS_REFCURSOR;
        BEGIN
        open c_all for
        SELECT * FROM User_ WHERE Username=User_Name AND Password=PASS;
        DBMS_SQL.RETURN_RESULT(c_all);
    end GetUser;
    
END Auth_Package;




