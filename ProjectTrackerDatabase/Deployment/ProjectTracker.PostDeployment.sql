/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



delete from dbo.Status;
dbcc checkident('dbo.Status', reseed, 0);


insert into dbo.Status values('New', 'New', 'system', getdate(), null, null);
insert into dbo.Status values('Active', 'In Progress', 'system', getdate(), null, null);
insert into dbo.Status values('Dev Complete', 'Developer work is complete', 'system', getdate(), null, null);
insert into dbo.Status values('QA Complete', 'QA work is complete', 'system', getdate(), null, null);
insert into dbo.Status values('Closed', 'All work is complete and release ready', 'system', getdate(), null, null);
	

delete from dbo.UserType;
dbcc checkident('dbo.UserType', reseed, 0);

insert into dbo.UserType values('Developer', 'Dev', 'system', getdate(), null, null);
insert into dbo.UserType values('Tester', 'QA', 'system', getdate(), null, null);
insert into dbo.UserType values('Project Manager', 'PM', 'system', getdate(), null, null);
insert into dbo.UserType values('Business Analyst', 'BA', 'system', getdate(), null, null);
insert into dbo.UserType values('Administrator', 'Admin', 'system', getdate(), null, null);






delete from dbo.Classification;
dbcc checkident('dbo.Classification', reseed, 0);


insert into dbo.Classification values('Architectural', 1, 'system', getdate(), null, null);
insert into dbo.Classification values('Business', 1, 'system', getdate(), null, null);
		

delete from dbo.Priority;
dbcc checkident('dbo.Priority', reseed, 0);

insert into dbo.Priority values('High', 1, 1,'system', getdate(), null, null);
insert into dbo.Priority values('Medium', 2, 1,'system', getdate(), null, null);
insert into dbo.Priority values('Low', 3, 1, 'system', getdate(), null, null);
		



delete from dbo.Risk;
dbcc checkident('dbo.Risk', reseed, 0);


insert into dbo.Risk values('High', 1, 1,'system', getdate(), null, null);
insert into dbo.Risk values('Medium', 2, 1,'system', getdate(), null, null);
insert into dbo.Risk values('Low', 3, 1, 'system', getdate(), null, null);
		



delete from dbo.Environment;
dbcc checkident('dbo.Environment', reseed, 0);

insert into dbo.Environment values('Development', 1, 'system', getdate(), null, null);
insert into dbo.Environment values('Test', 1,'system', getdate(), null, null);
insert into dbo.Environment values('Staging', 1,'system', getdate(), null, null);
insert into dbo.Environment values('Production', 1, 'system', getdate(), null, null);




delete from dbo.ActivityType;
dbcc checkident('dbo.ActivityType', reseed, 0);

insert into dbo.ActivityType values('Deployment', 1, 'system', getdate(), null, null);
insert into dbo.ActivityType values('Design', 1,'system', getdate(), null, null);
insert into dbo.ActivityType values('Development', 1,'system', getdate(), null, null);
insert into dbo.ActivityType values('Documentation', 1, 'system', getdate(), null, null);
insert into dbo.ActivityType values('Requirements', 1, 'system', getdate(), null, null);
insert into dbo.ActivityType values('Testing', 1, 'system', getdate(), null, null);



