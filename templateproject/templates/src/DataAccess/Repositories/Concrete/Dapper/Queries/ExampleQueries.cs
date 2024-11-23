namespace ZACx.Templates.WebApiProject.DataAccess.Repositories.Concrete.Dapper.Queries
{
    internal class ExampleQueries
    {
        internal const string EXAMPLES_INSERT_QUERY = @"
	INSERT INTO Examples (
		 Code
		,Name
		,Description
		,DoSendMail
		,CreatedUserId
		,ModifiedUserId
		)
	VALUES (
		 @Code
		,@Name
		,@Description
		,@DoSendMail
		,@CreatedUserId
		,@ModifiedUserId
		)
";

        internal const string EXAMPLES_GETALL_QUERY = @"
	SELECT 
		 ExampleId
		,Code
		,Name
		,Description
		,DoSendMail
		,IsActive
		,IsDeleted
		,CreatedTime
		,CreatedUserId
		,ModifiedTime
		,ModifiedUserId
		,DeletedTime
		,DeletedUserId
	FROM Examples
	WHERE 1=1
";

        internal const string EXAMPLES_GETBYID_QUERY = @"
	SELECT 
		 ExampleId
		,Code
		,Name
		,Description
		,DoSendMail
		,IsActive
		,IsDeleted
		,CreatedTime
		,CreatedUserId
		,ModifiedTime
		,ModifiedUserId
		,DeletedTime
		,DeletedUserId
	FROM Examples
	WHERE 1=1
	AND ExampleId = @ExampleId
";

        internal const string EXAMPLES_UPDATE_QUERY = @"
	UPDATE Examples
	SET  Code = @Code
		,Name = @Name
		,Description = @Description
		,DoSendMail = @DoSendMail
		,IsActive = @IsActive 
		,IsDeleted = @IsDeleted
		,ModifiedTime = @ModifiedTime
		,ModifiedUserId = @ModifiedUserId
		,DeletedTime = @DeletedTime
		,DeletedUserId = @DeletedUserId
	FROM Examples
	WHERE 1=1
	AND ExampleId = @ExampleId
";
    }
}
