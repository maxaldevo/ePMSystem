using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM_Dal.Enums
{
   public static class PublicEnums
    {
        public enum TrGroupHistoryActions
        {
            Add_Group,
            Update_Group,
            Add_Trainee,
            Delete_Trainee,
            Delete_Group
        }
        public enum CourseAssignActions
        {
            Add_Course,
            Remove_Course
        }
        public enum ExamResultStatus
        { 
            Enrolled, NoShow, Completed
        }
        public enum ExamResultAssessment
        {
            Competent,
            NotYetCompetent
        }
        public enum TrSessionHistory
        {
            AddSession,
            UpdateSession,
            DeleteSession
        }
        public enum TrTranscriptHistory
        {
            AddTranscript,
            UpdateTranscript,
            DeleteTranscript
        }
        public static string getTranscriptActions(TrTranscriptHistory actions)
        {
            string actionType = "";
            switch (actions)
            {
                case TrTranscriptHistory.AddTranscript:
                    actionType = "Add_Transcript";
                    break;
                case TrTranscriptHistory.UpdateTranscript:
                    actionType = "Update_Transcript";
                    break;
                case TrTranscriptHistory.DeleteTranscript:
                    actionType = "Delete_Transcript";
                    break;
                default:
                    actionType = "UnDefined";
                    break;
            }
            return actionType;
        }
        public static string getActionType(TrGroupHistoryActions actions)
        {
            string actionType = ""; 
            switch (actions)
            {
                case TrGroupHistoryActions.Add_Group:
                    actionType = "Add_Group";
                    break;
                case TrGroupHistoryActions.Update_Group:
                    actionType = "Update_Group";
                    break;
                case TrGroupHistoryActions.Add_Trainee:
                    actionType = "Add_Trainee";
                    break;
                case TrGroupHistoryActions.Delete_Trainee:
                    actionType = "Delete_Trainee";
                    break;
                case TrGroupHistoryActions.Delete_Group:
                    actionType = "Delete_Group";
                    break;
                default:
                    actionType = "UnDefined";
                    break;
            }
            return actionType;
        }
        public static string getCourseAssignActions(CourseAssignActions actions)
        {
            string actionType = "";
            switch (actions)
            {
                case CourseAssignActions.Add_Course:
                    actionType = "Add_Course";
                    break;
                case CourseAssignActions.Remove_Course:
                    actionType = "Remove_Course";
                    break;
                default:
                    actionType = "UnDefined";
                    break;
            }
            return actionType;
        }
        public static string getExamResultStatus(ExamResultStatus status)
        {
            string actionType = "";
            switch (status)
            {
                case ExamResultStatus.NoShow:
                    actionType = "No-Show";
                    break;
                case ExamResultStatus.Completed:
                    actionType = "Completed";
                    break;
                case ExamResultStatus.Enrolled:
                    actionType = "Enrolled";
                    break;
                default:
                    actionType = "Enrolled";
                    break;
            }
            return actionType;
        }
        public static string getExamResultAssessment(ExamResultAssessment status)
        {
            string actionType = "";
            switch (status)
            {
                case ExamResultAssessment.Competent:
                    actionType = "COMPETENT";
                    break;
                case ExamResultAssessment.NotYetCompetent:
                    actionType = "NOT YET COMPETENT";
                    break;
                default:
                    actionType = "NOT YET COMPETENT";
                    break;
            }
            return actionType;
        }
        public static string GetSessHist(TrSessionHistory actions)
        {
            string actionType = "";
            switch (actions)
            {
                case TrSessionHistory.AddSession:
                    actionType = "Add_Session";
                    break;
                case TrSessionHistory.UpdateSession:
                    actionType = "Update_Session";
                    break;
                case TrSessionHistory.DeleteSession:
                    actionType = "Delete_Session";
                    break;
 
                default:
                    actionType = "UnDefined";
                    break;
            }
            return actionType;
        }

    }
}
