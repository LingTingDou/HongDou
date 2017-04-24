namespace HongDou.Infrasturcture.Data
{
    public partial class DBObject : DataObject<int>
    {
        public override bool Equals(DataObject<int> other)
        {
            if (ReferenceEquals(other, null))
                return false;

            return this.ID == other.ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
