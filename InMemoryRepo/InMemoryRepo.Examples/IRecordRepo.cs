namespace InMemoryRepo.Examples
{
    public interface IRecordRepo
    {
        int Create(Record record);

        Record Get(int id);

        //bool Update(Record record);

        //bool Delete(Record record);
    }
}
