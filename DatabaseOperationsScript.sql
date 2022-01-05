-- Creating a user table
Create table user_tbl(   

UserId int IDENTITY(1,1) NOT NULL,   

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

BookId int IDENTITY(1,1) NOT NULL,   

BookTitle varchar(50) NOT NULL,   

AuthorName varchar(50) NOT NULL,   

Rating float,   

RatingCount int,

OriginalPrice int NOT NULL,

DiscountedPrice int NOT NULL,

Description varchar(max) NOT NULL,

BookQty int NOT NULL,

Image varchar(100)

)