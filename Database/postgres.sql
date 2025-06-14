
 
CREATE TABLE ActivityType(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_ActivityType PRIMARY KEY (Id));

 
CREATE TABLE Classification(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Classification PRIMARY KEY (	Id) );

 
CREATE TABLE Environment(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Environment PRIMARY KEY ( Id ));

 
CREATE TABLE Feature(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Title Varchar(100) NOT NULL,
	Description Text NULL,
	ProjectId int NOT NULL,
	PriorityId int NULL,
	RiskId int NULL,
	ClassificationId int NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Feature PRIMARY KEY (Id) ) ;

 
CREATE TABLE Issue(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Title Varchar(1000) NOT NULL,
	Description Text NULL,
	ProjectId int NOT NULL,
	StatusId int NOT NULL,
	AssignedToId int NULL,
	SprintId int NULL,
	SprintTypeId int NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Issue PRIMARY KEY 
(
	Id
) 
) ;
/* SQLINES DEMO *** le [dbo].[Log]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE Log(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Type Varchar(20) NOT NULL,
	Message Varchar(1000) NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
 CONSTRAINT PK_Log PRIMARY KEY 
(
	Id
) 
);
/* SQLINES DEMO *** le [dbo].[Priority]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE Priority(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	Value int NOT NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Priority PRIMARY KEY 
(
	Id
) 
);
/* SQLINES DEMO *** le [dbo].[Project]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE Project(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	Description Text NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Project PRIMARY KEY 
(
	Id
) 
) ;
/* SQLINES DEMO *** le [dbo].[Risk]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE Risk(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	Value int NOT NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Risk PRIMARY KEY 
(
	Id
) 
);
/* SQLINES DEMO *** le [dbo].[Sprint]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE Sprint(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	StartDate date NOT NULL,
	EndDate date NOT NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Sprint PRIMARY KEY 
(
	Id
) 
);
/* SQLINES DEMO *** le [dbo].[SprintType]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE SprintType(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(10) NOT NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_SprintType PRIMARY KEY 
(
	Id
) 
);
/* SQLINES DEMO *** le [dbo].[Status]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE Status(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	Value Varchar(1000) NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Status PRIMARY KEY 
(
	Id
) 
);
/* SQLINES DEMO *** le [dbo].[Task]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE Task(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Title Varchar(100) NOT NULL,
	Description Text NULL,
	Effort numeric(3, 2) NULL,
	UserStoryId int NOT NULL,
	AssignedToId int NULL,
	PriorityId int NULL,
	ActivityTypeId int NULL,
	EnvironmentId int NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_Task PRIMARY KEY 
(
	Id
) 
) ;
/* SQLINES DEMO *** le [dbo].[User]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE Users(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	UserTypeId int NOT NULL,
	Email Varchar(100) NULL,
	LoginId Varchar(100) NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_User PRIMARY KEY 
(
	Id
) 
);
/* SQLINES DEMO *** le [dbo].[UserStory]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE UserStory(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Title Varchar(100) NOT NULL,
	Description Text NULL,
	AcceptanceCriteria Text NULL,
	StoryPoints int NULL,
	PriorityId int NULL,
	RiskId int NULL,
	ClassificationId int NULL,
	FeatureId int NOT NULL,
	SprintId int NULL,
	SprintTypeId int NOT NULL,
	Active Boolean NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_UserStory PRIMARY KEY 
(
	Id
) 
) ;
/* SQLINES DEMO *** le [dbo].[UserType]    Script Date: 9/29/2024 4:16:28 PM ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE TABLE UserType(
	Id int GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	Name Varchar(100) NOT NULL,
	Value Varchar(100) NOT NULL,
	CreatedBy Varchar(100) NOT NULL,
	CreatedDate Timestamp(3) NOT NULL,
	ModifiedBy Varchar(100) NULL,
	ModifiedDate Timestamp(3) NULL,
 CONSTRAINT PK_UserType PRIMARY KEY 
(
	Id
) 
);
ALTER TABLE ActivityType ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Classification ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Environment ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Feature ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Issue ALTER COLUMN StatusId  SET DEFAULT ((1)) ;
 
ALTER TABLE Issue ALTER COLUMN SprintTypeId  SET DEFAULT ((1)) ;
 
ALTER TABLE Priority ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Project ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Risk ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Sprint ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE SprintType ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Task ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Users ALTER COLUMN Active  SET DEFAULT true;
 
ALTER TABLE UserStory ALTER COLUMN SprintTypeId  SET DEFAULT ((1)) ;
 
ALTER TABLE UserStory ALTER COLUMN Active  SET DEFAULT true ;
 
ALTER TABLE Feature ADD  CONSTRAINT FK_Feature_ClassificationId FOREIGN KEY(ClassificationId)
REFERENCES Classification (Id) NOT VALID;
 
ALTER TABLE Feature VALIDATE CONSTRAINT FK_Feature_ClassificationId;
 
ALTER TABLE Feature ADD  CONSTRAINT FK_Feature_PriorityId FOREIGN KEY(PriorityId)
REFERENCES Priority (Id) NOT VALID;
 
ALTER TABLE Feature VALIDATE CONSTRAINT FK_Feature_PriorityId;
 
ALTER TABLE Feature ADD  CONSTRAINT FK_Feature_ProjectId FOREIGN KEY(ProjectId)
REFERENCES Project (Id) NOT VALID;
 
ALTER TABLE Feature VALIDATE CONSTRAINT FK_Feature_ProjectId;
 
ALTER TABLE Feature ADD  CONSTRAINT FK_Feature_RiskId FOREIGN KEY(RiskId)
REFERENCES Risk (Id) NOT VALID;
 
ALTER TABLE Feature VALIDATE CONSTRAINT FK_Feature_RiskId;
 
ALTER TABLE Issue ADD  CONSTRAINT FK_Issue_AssignedToId FOREIGN KEY(AssignedToId)
REFERENCES Users (Id) NOT VALID;
 
ALTER TABLE Issue VALIDATE CONSTRAINT FK_Issue_AssignedToId;
 
ALTER TABLE Issue ADD  CONSTRAINT FK_Issue_ProjectId FOREIGN KEY(ProjectId)
REFERENCES Project (Id) NOT VALID;
 
ALTER TABLE Issue VALIDATE CONSTRAINT FK_Issue_ProjectId;
 
ALTER TABLE Issue ADD  CONSTRAINT FK_Issue_SprintId FOREIGN KEY(SprintId)
REFERENCES Sprint (Id) NOT VALID;
 
ALTER TABLE Issue VALIDATE CONSTRAINT FK_Issue_SprintId;
 
ALTER TABLE Issue ADD  CONSTRAINT FK_Issue_SprintTypeId FOREIGN KEY(SprintTypeId)
REFERENCES SprintType (Id) NOT VALID;
 
ALTER TABLE Issue VALIDATE CONSTRAINT FK_Issue_SprintTypeId;
 
ALTER TABLE Issue ADD  CONSTRAINT FK_Issue_StatusId FOREIGN KEY(StatusId)
REFERENCES Status (Id) NOT VALID;
 
ALTER TABLE Issue VALIDATE CONSTRAINT FK_Issue_StatusId;
 
ALTER TABLE Task ADD  CONSTRAINT FK_Task_ActivityTypeId FOREIGN KEY(ActivityTypeId)
REFERENCES ActivityType (Id) NOT VALID;
 
ALTER TABLE Task VALIDATE CONSTRAINT FK_Task_ActivityTypeId;
 
ALTER TABLE Task ADD  CONSTRAINT FK_Task_AssignedToId FOREIGN KEY(AssignedToId)
REFERENCES Users (Id) NOT VALID;
 
ALTER TABLE Task VALIDATE CONSTRAINT FK_Task_AssignedToId;
 
ALTER TABLE Task ADD  CONSTRAINT FK_Task_EnvironmentId FOREIGN KEY(EnvironmentId)
REFERENCES Environment (Id) NOT VALID;
 
ALTER TABLE Task VALIDATE CONSTRAINT FK_Task_EnvironmentId;
 
ALTER TABLE Task ADD  CONSTRAINT FK_Task_PriorityId FOREIGN KEY(PriorityId)
REFERENCES Priority (Id) NOT VALID;
 
ALTER TABLE Task VALIDATE CONSTRAINT FK_Task_PriorityId;
 
ALTER TABLE Task ADD  CONSTRAINT FK_Task_UserStoryId FOREIGN KEY(UserStoryId)
REFERENCES UserStory (Id) NOT VALID;
 
ALTER TABLE Task VALIDATE CONSTRAINT FK_Task_UserStoryId;
 
ALTER TABLE Users ADD  CONSTRAINT FK_User_UserTypeId FOREIGN KEY(UserTypeId)
REFERENCES UserType (Id) NOT VALID;
 
ALTER TABLE Users VALIDATE CONSTRAINT FK_User_UserTypeId;
 
ALTER TABLE UserStory ADD  CONSTRAINT FK_UserStory_ClassificationId FOREIGN KEY(ClassificationId)
REFERENCES Classification (Id) NOT VALID;
 
ALTER TABLE UserStory VALIDATE CONSTRAINT FK_UserStory_ClassificationId;
 
ALTER TABLE UserStory ADD  CONSTRAINT FK_UserStory_FeatureId FOREIGN KEY(FeatureId)
REFERENCES Feature (Id) NOT VALID;
 
ALTER TABLE UserStory VALIDATE CONSTRAINT FK_UserStory_FeatureId;
 
ALTER TABLE UserStory ADD  CONSTRAINT FK_UserStory_PriorityId FOREIGN KEY(PriorityId)
REFERENCES Priority (Id) NOT VALID;
 
ALTER TABLE UserStory VALIDATE CONSTRAINT FK_UserStory_PriorityId;
 
ALTER TABLE UserStory ADD  CONSTRAINT FK_UserStory_RiskId FOREIGN KEY(RiskId)
REFERENCES Risk (Id) NOT VALID;
 
ALTER TABLE UserStory VALIDATE CONSTRAINT FK_UserStory_RiskId;
 
ALTER TABLE UserStory ADD  CONSTRAINT FK_UserStory_SprintId FOREIGN KEY(SprintId)
REFERENCES Sprint (Id) NOT VALID;
 
ALTER TABLE UserStory VALIDATE CONSTRAINT FK_UserStory_SprintId;
 
ALTER TABLE UserStory ADD  CONSTRAINT FK_UserStory_SprintTypeId FOREIGN KEY(SprintTypeId)
REFERENCES SprintType (Id) NOT VALID;
 
ALTER TABLE UserStory VALIDATE CONSTRAINT FK_UserStory_SprintTypeId;
 



 
/* SET IDENTITY_INSERT [dbo].[ActivityType] ON */ 
 
-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
INSERT INTO ActivityType (Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES  ('Deployment', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
																								   
INSERT INTO ActivityType ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Design', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
																								   
INSERT INTO ActivityType ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Development', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
																								   
INSERT INTO ActivityType ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Documentation', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
																								   
INSERT INTO ActivityType ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Requirements', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
																								   
INSERT INTO ActivityType ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Testing', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
 
 select * from ActivityType;
 
/* SET IDENTITY_INSERT [dbo].[ActivityType] OFF */
 
/* SET IDENTITY_INSERT [dbo].[Environment] ON */ 
 
INSERT INTO Environment ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Development', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Environment ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Test', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Environment ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Staging', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Environment ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Production', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
 select * from Environment;
 
 
 
/* SET IDENTITY_INSERT [dbo].[Environment] OFF */
 
/* SET IDENTITY_INSERT [dbo].[Priority] ON */ 
 
INSERT INTO Priority ( Name, Value, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('High', '1', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Priority ( Name, Value, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Medium', '2', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Priority ( Name, Value, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Low', '3', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
 select * from Priority;
 
/* SET IDENTITY_INSERT [dbo].[Priority] OFF */
 
/* SET IDENTITY_INSERT [dbo].[UserType] ON */ 
 
INSERT INTO UserType ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Developer', 'Dev', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO UserType ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Tester', 'QA', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO UserType ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Project Manager', 'PM', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO UserType ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Business Analyst', 'BA', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO UserType ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Administrator', 'Admin', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
 select * from UserType;
 
/* SET IDENTITY_INSERT [dbo].[UserType] OFF */
 
/* SET IDENTITY_INSERT [dbo].[Classification] ON */ 
 
INSERT INTO Classification ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Architectural', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Classification ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Business', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
 select * from Classification;
 
 
/* SET IDENTITY_INSERT [dbo].[Classification] OFF */
 
/* SET IDENTITY_INSERT [dbo].[Project] ON */ 
 
INSERT INTO Project ( Name, Description, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ( 'ProjectTracker', 'Build a project tracking system which can track sprint progress, issues, user stories, and other artifacts.', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Project ( Name, Description, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ( 'AuthenticateApp', 'Build a authentication system. Get the username and password from user. Set it in request form params and send it to the server. Server validates the user based on the given username and password?. Once successful validation, create a cookie and set it in the response. The client then uses this cookie/session to make future requests.', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Project ( Name, Description, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ( 'LogApp', 'Build a logging system for any application. Expose an api which application can be called. This system should track information, warning, or error level logging. Purpose of this app is to move any logging per app to this system.', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Project ( Name, Description, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Test 1', 'Testing 1', True, 'Tejinder', CAST('2023-02-15T19:56:08.607' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Project ( Name, Description, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Test 2', 'Testing 2', True, 'Tejinder', CAST('2023-02-15T19:57:21.963' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Project ( Name, Description, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Test 3', 'Test 3', True, 'Tejinder', CAST('2023-02-19T18:33:28.870' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Project ( Name, Description, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES (	 'Test 4 updated again', 'Test Description 4 updated again', True, 'Tejinder', CAST('2023-05-29T08:25:35.590' AS TIMESTAMP(3)), 'Tejinderpal Virdee', CAST('2023-05-29T09:08:01.727' AS TIMESTAMP(3)));
 
 select * from Project;
 
 
/* SET IDENTITY_INSERT [dbo].[Project] OFF */
 
/* SET IDENTITY_INSERT [dbo].[Risk] ON */ 
 
INSERT INTO Risk ( Name, Value, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('High', '1', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
																								  
INSERT INTO Risk ( Name, Value, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Medium', '2', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
																								  
INSERT INTO Risk ( Name, Value, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Low', '3', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
 select * from Risk;
 
/* SET IDENTITY_INSERT [dbo].[Risk] OFF */
 
/* SET IDENTITY_INSERT [dbo].[Feature] ON */ 
 
INSERT INTO Feature ( Title, Description, ProjectId, PriorityId, RiskId, ClassificationId, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
VALUES ('Test' -- Title
	, '' -- Description
	, (select id from Project where name = 'ProjectTracker')	-- ProjectId
	, (select id from Priority where name = 'Low')	-- PriorityId
	, (select id from Risk where name = 'Low' ) -- RiskId
	, (select id from Classification where name = 'Business')	-- ClassificationId
	, True	-- Active
	, 'system'	-- CreatedBy
	, CAST('2022-06-20T00:22:10.183' AS TIMESTAMP(3))	-- CreatedDate
	, NULL	-- ModifiedBy
	, NULL	-- ModifiedDate
  );
  
 select * from Feature;
 
/* SET IDENTITY_INSERT [dbo].[Feature] OFF */
 
/* SET IDENTITY_INSERT [dbo].[Sprint] ON */ 
 
INSERT INTO Sprint ( Name, StartDate, EndDate, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Sprint 1', CAST('2022-01-01' AS Date), CAST('2022-02-01' AS Date), True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
 
/* SET IDENTITY_INSERT [dbo].[Sprint] OFF */
 
/* SET IDENTITY_INSERT [dbo].[SprintType] ON */ 
 
INSERT INTO SprintType ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('New', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO SprintType ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Active', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO SprintType ( Name, Active, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Closed', True, 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
/* SET IDENTITY_INSERT [dbo].[SprintType] OFF */
 
/* SET IDENTITY_INSERT [dbo].[Status] ON */ 
 
INSERT INTO Status ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('New', 'New', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Status ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Active', 'In Progress', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Status ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Dev Complete', 'Developer work is complete', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Status ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('QA Complete', 'QA work is complete', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
INSERT INTO Status ( Name, Value, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES ('Closed', 'All work is complete and release ready', 'system', CAST('2022-06-20T00:13:13.813' AS TIMESTAMP(3)), NULL, NULL);
 
/* SET IDENTITY_INSERT [dbo].[Status] OFF */
 
/* SET IDENTITY_INSERT [dbo].[Log] ON */ 
 
INSERT INTO Log ( Type, Message, CreatedBy, CreatedDate) VALUES ('Info', 'Test 1', 'system', CAST('2023-05-13T15:12:52.860' AS TIMESTAMP(3)));
 
INSERT INTO Log ( Type, Message, CreatedBy, CreatedDate) VALUES ('Info', 'Test 2', 'system', CAST('2023-05-13T15:13:19.430' AS TIMESTAMP(3)));
 
INSERT INTO Log ( Type, Message, CreatedBy, CreatedDate) VALUES ('Warning', 'Warning 1', 'system', CAST('2023-05-13T15:13:19.430' AS TIMESTAMP(3)));
 
INSERT INTO Log ( Type, Message, CreatedBy, CreatedDate) VALUES ('Warning', 'Warning 2', 'system', CAST('2023-05-13T15:13:19.430' AS TIMESTAMP(3)));
 
INSERT INTO Log ( Type, Message, CreatedBy, CreatedDate) VALUES ('Error', 'Error 1', 'system', CAST('2023-05-13T15:13:19.430' AS TIMESTAMP(3)));

INSERT INTO Log ( Type, Message, CreatedBy, CreatedDate) VALUES ('Error', 'Error 2', 'system', CAST('2023-05-13T15:13:19.430' AS TIMESTAMP(3)));
  
select * from Log
 
/* SET IDENTITY_INSERT [dbo].[Log] OFF */
 
