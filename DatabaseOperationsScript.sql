-- Creating a user table
Create table user_tbl(   

UserId int IDENTITY(1,1) NOT NULL PRIMARY KEY,   

FullName varchar(20) NOT NULL,   

EmailId varchar(50) NOT NULL,   

Password varchar(20) NOT NULL,   

MobileNum bigint NOT NULL  

)

-- Creating a stored procedure for adding the users
Create procedure spForAddingUsers    

(   

    @FullName VARCHAR(20),    

    @EmailId VARCHAR(50),   

    @Password VARCHAR(20),   

    @MobileNum bigint   

)   

as    

Begin    

    Insert into user_tbl (FullName,EmailId,Password, MobileNum)    

    Values (@FullName,@EmailId,@Password, @MobileNum)    

End

-- Creating a stored procedure for getting the user details
Create procedure spForGettingAllUsers   

as   

Begin   

    select

                   UserId,

                   FullName,

                   EmailId,

                   Password,   

                   MobileNum

    from user_tbl   

End

-- Creating a stored procedure for getting the details of a specific user
Create procedure spForGettingASingleUser
(    
    @UserId int
)    
as     
Begin     
    SELECT * FROM user_tbl WHERE UserID= @UserId
End

-- Creating a stored procedure for updating the user details
Create procedure spForUpdatingUsers     

(     

   @UserId INTEGER ,   

   @FullName VARCHAR(20),    

   @EmailId VARCHAR(50),   

   @Password VARCHAR(20),   

   @MobileNum bigint   

)     

as     

begin     

   Update user_tbl      

   set FullName=@FullName,     

   EmailId=@EmailId,     

   Password=@Password,   

   MobileNum=@MobileNum     

   where UserId=@UserId     

End

-- Creating a stored procedure for deleting a user
Create procedure spForDeletingUsers    

(     

   @UserId int     

)     

as      

begin     

   Delete from user_tbl where UserId=@UserId     

End

-- Creating a stored procedure for login
Create procedure spForLogin 

(       

    @EmailId VARCHAR(50),   

    @Password VARCHAR(20)

)   

as    

Begin    

	SELECT EmailId, Password FROM user_tbl WHERE EmailId= @EmailId and Password=@Password
End

-- Creating a stored procedure for password reset
Create procedure spForResetPassword

(       

    @EmailId VARCHAR(50),   

    @NewPassword VARCHAR(20)

)   

as    

Begin    

	Update user_tbl
	
	set Password=@NewPassword

	where EmailId=@EmailId

	SELECT EmailId, Password FROM user_tbl WHERE EmailId= @EmailId and Password=@NewPassword

End

-- Creating a stored procedure for forgot password
Create procedure spForForgotPassword

(       

    @EmailId VARCHAR(50) 

)   

as    

Begin    

	SELECT EmailId FROM user_tbl WHERE EmailId= @EmailId

End


-- Creating a book details table
Create table bookdetails_tbl(   

BookId int IDENTITY(1,1) NOT NULL PRIMARY KEY,   

BookTitle varchar(50),   

AuthorName varchar(50),   

Rating float,   

RatingCount int,

OriginalPrice int,

DiscountedPrice int,

Description varchar(max),

BookQty int,

Image varchar(100)

)

select * from bookdetails_tbl;

-- Creating a stored procedure for adding the book details
Create procedure spForAddingBookDetails    

(   

    @BookTitle VARCHAR(50),    

    @AuthorName VARCHAR(20),   

    @Rating float,   

    @RatingCount int,
	
	@OriginalPrice int,
	
	@DiscountedPrice int,
	
	@Description varchar(max),

	@BookQty int,

	@Image varchar(100)

)   

as    

Begin    

    Insert into bookdetails_tbl (BookTitle,AuthorName,Rating,RatingCount,OriginalPrice,DiscountedPrice,Description,BookQty,Image)    

    Values (@BookTitle,@AuthorName,@Rating,@RatingCount,@OriginalPrice,@DiscountedPrice,@Description,@BookQty,@Image)    

	SELECT * FROM bookdetails_tbl;

End

-- Creating a stored procedure for deleting book details
Create procedure spForDeletingBookDetails    

(     

   @BookId int     

)     

as      

begin     

   Delete from bookdetails_tbl where BookId=@BookId     

End

-- Creating a stored procedure for updating the book details
Create procedure spForUpdatingBookDetails     

(     

   @BookId INTEGER ,   

   @Rating float,    

   @RatingCount int,   

   @OriginalPrice int,  

   @DiscountedPrice int,

   @Description varchar(max),

   @BookQty int,

   @Image varchar(100)

)     

as     

begin     

   Update bookdetails_tbl      

   set Rating=@Rating,     

   RatingCount=@RatingCount,     

   OriginalPrice=@OriginalPrice,   

   DiscountedPrice=@DiscountedPrice,     

   Description=@Description,

   BookQty=@BookQty,

   Image=@Image

   where BookId=@BookId     

End

-- Creating a stored procedure for getting the details of a specific book
Create procedure spForGettingSingleBookDetails
(    
    @BookId int
)    
as     
Begin     
    SELECT * FROM bookdetails_tbl WHERE BookId= @BookId
End

-- Creating a stored procedure for getting the details of all books in the table
Create procedure spForGettingAllBookDetails
    
as
     
Begin
     
    SELECT * FROM bookdetails_tbl

End

-- Creating a cart details table
Create table cartdetails_tbl(   

CartId int IDENTITY(1,1) NOT NULL PRIMARY KEY,   
 
UserId int FOREIGN KEY REFERENCES user_tbl(UserId),   

BookId int FOREIGN KEY REFERENCES bookdetails_tbl(BookId),  

QtyToOrder int default 1   

)

-- Creating a stored procedure for adding book to cart
Alter PROCEDURE spAddingBookToCart(

	@UserId INT,

	@BookId INT,
	
	@QtyToOrder INT)

AS

BEGIN

		INSERT INTO cartdetails_tbl( UserId,BookId,QtyToOrder)

		VALUES (@UserId,@BookId,@QtyToOrder)

		Select * from cartdetails_tbl;
END

-- Creating a stored procedure for updating book quantity in the cart
CREATE PROC spForUpdatingBookQuantity

	@CartId INT,

	@QtyToOrder INT

AS

BEGIN

	IF (EXISTS(SELECT * FROM cartdetails_tbl WHERE CartId = @CartId))

	BEGIN

			UPDATE cartdetails_tbl

			SET

				QtyToOrder = @QtyToOrder

			WHERE

				CartId = @CartId;

		END

		ELSE

		BEGIN

			Select 1;

		END

END
