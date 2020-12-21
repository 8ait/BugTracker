namespace Leonov.BugTracker.Authenticate
{
    using System.ComponentModel;

    /// <summary>
    /// Права пользователя.
    /// </summary>
    public enum Arm
    {
        Default,

        [Description("create_project")]
        CreateProject,

        [Description("edit_project")]
        EditProject,

        [Description("delete_project")]
        DeleteProject,

        [Description("create_error")]
        CreateError,

        [Description("edit_error")]
        EditError,

        [Description("delete_error")]
        DeleteError,

        [Description("edit_status_error")]
        EditStatusError,

        [Description("can_edit_user_information")]
        CanEditUserInformation,

        [Description("administrator_panel")]
        AdministratorPanel
    }
}
