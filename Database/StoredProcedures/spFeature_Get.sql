CREATE PROCEDURE [dbo].[spFeature_Get]
	@id int
AS
BEGIN
	begin try
		select Title, 
			[Description],
			ProjectId,
			PriorityId,
			RiskId,
			ClassificationId,
			Active, 
			CreatedBy, 
			CreatedDate, 
			ModifiedBy, 
			ModifiedDate 
		from dbo.Feature
		where id = @id

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