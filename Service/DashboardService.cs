namespace Service
{
    public class DashboardService
    {
        public int CampusCount()
        {
            return 1;
        }

        public int EventCount()
        {
            return 1;
        }

        public int FormCount()
        {
            return 1;
        }

        public int MemberCount()
        {
            return 1;
        }

        public int MenuElementCount()
        {
            return 1;
        }

        public int NewsCount()
        {
            return 1;
        }

        public int PageCount()
        {
            return 1;
        }

        public int StaffCount()
        {
            return 1;
        }
    }

    public interface IDashboardService
    {
        int CampusCount();
        int EventCount();
        int FormCount();
        int MemberCount();

    }
}