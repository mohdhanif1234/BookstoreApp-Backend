-- Creating a user table
Create table user_tbl(   

UserId int IDENTITY(1,1) NOT NULL,   

FullName varchar(20) NOT NULL,   

EmailId varchar(20) NOT NULL,   

Password varchar(20) NOT NULL,   

MobileNum bigint NOT NULL  

)

-- Creating a stored procedure for adding the users
Create procedure spForAddingUsers    

(   

    @FullName VARCHAR(20),    

    @EmailId VARCHAR(20),   

    @Password VARCHAR(20),   

    @MobileNum bigint   

)   

as    

Begin    

    Insert into users_tbl (FullName,EmailId,Password, MobileNum)    

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