namespace HongDou.Infrasturcture.Data
{
    public abstract partial class IntIDDataObject : BaseDataObject<int>
    {
        public override bool Equals(BaseDataObject<int> other)
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
