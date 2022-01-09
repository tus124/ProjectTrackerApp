CREATE PROCEDURE [dbo].[spIssue_GetAllByProjectId]
	@projectId int
AS
BEGIN
	begin try
		select Title
			, Description
			, (select Name from dbo.[Status] where id = statusId) as Status
			, (select Name from dbo.[User] where id = assignedtoId) as AssignedTo
			, (select Name from dbo.Sprint where id = sprintId) as Sprint
			, (select Name from dbo.SprintType where id = sprintTypeId) as SprintType

		from dbo.Issue
		where projectId = @projectId


	end try
	begin catch
		SELECT  
			ERROR_NUMBER() AS ErrorNumber  
			,ERROR_SEVERITY() AS ErrorSeverity  
			,ERROR_STATE() AS ErrorState  
			,ERROR_PROCEDURE() AS ErrorProcedure  
			,ERROR_LINE() AS ErrorLine  
			,ERROR_MESSAGE() AS ErrorMessage;  


		throw;
	end catch


END