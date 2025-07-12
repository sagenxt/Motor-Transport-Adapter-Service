
namespace Motor.Transport.Adapter.Repository.Constant
{
    public class DbConstants
    {
        #region "Worker"

        #region "Stored Procedure Parameters"

        public const string P_WORKER_ID = "Worker_Id";
        public const string P_FIRST_NAME = "First_Name";
        public const string P_MIDDLE_NAME = "Middle_Name";
        public const string P_LAST_NAME = "Last_Name";
        public const string P_MOBILE_NUMBER = "Mobile_Number";
        public const string P_EMAIL_ID = "Email_Id";

        public const string P_SHEET_ID = "Sheet_Id";
        public const string P_WORK_DATE = "Work_Date";
        public const string P_DAY_OF_WEEK = "Day_Of_Week";
        public const string P_ON_DUTY_OR_REST = "On_Duty_Or_Rest";
        public const string P_ENDING_WORK_DATE = "Ending_Work_Date";
        public const string P_PERIOD_OF_VEHICLE_IS_ON_ROAD = "Period_Of_Vehice_Is_On_Road";
        public const string P_PERIOD_OF_INTERRUPTION = "Period_Of_Interruption";
        public const string P_RUNNING_TIME = "Running_Time";
        public const string P_SUBSIDIARY_WORK_TIME = "Subsidiary_Work_Time";
        public const string P_PERIOD_OF_MERE_ATTENDANCE = "Period_Of_Mere_Attendance";
        public const string P_HOURS_OF_WORK = "Hours_Of_Work";
        public const string P_REST_INTERVAL = "Rest_Interval";
        public const string P_OVERTIME_LENGTH_WORKED = "Overtime_Length_Worked";
        public const string P_OVERTIME_LENGTH_WORKED_REASON = "Overtime_Length_Worked_Reason";
        public const string P_REMARKS = "Remarks";


        public const string P_OTP_CODE = "Otp_Code";
        public const string P_CREATED_AT = "Created_At";
        public const string P_EXPIRES_AT = "Expires_At";

        #endregion

        #region "Stored Procedure Names"

        public const string USP_PERSIST_WORKER_DETAILS = "usp_Persist_Worker_Details";
        public const string USP_PERSIST_WORKER_CONTROLE_DETAILS = "usp_Persist_Worker_Control_Details";
        public const string USP_PERSIST_OTP_VERIFCATION_DETAILS = "usp_Persist_Otp_Verification_Details";
        public const string USP_GET_WORKER_DETAILS_ON_MOBILE_NUMBER = "usp_Get_Worker_Details_On_Mobile_Number";
        public const string USP_GET_WORKER_CONTROLE_DETAILS_ON_WORKER_ID = "usp_Get_Worker_Control_Details_By_WorkerId";
        public const string USP_GET_WORKER_LOGIN_DETAILS = "usp_Get_Worker_Login_Details";

        #endregion

        #endregion

        #region "Common Stored Procedure Parameters"

        public const string P_LATITUDE = "Latitude";
        public const string P_LONGITUDE = "Longitude";

        public const string P_STATUS_CODE = "StatusCode";
        public const string P_MESSAGE = "Message";


        #endregion
    }
}
