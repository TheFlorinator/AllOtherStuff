using System;
using System.Collections.Generic;

namespace InMemoryRepo.Examples
{
    public class InMemoryRecordRepo : IRecordRepo
    {
        /// <summary>
        /// A static list of records. This will persist in memory even after we're done using the InMemoryRecordRepo, but it will stop persisting once we close the application.
        /// </summary>
        private static readonly List<Record> Records;

        /// <summary>
        /// The static constructor for InMemoryRecordRepo in which the static Records field will be initialized.
        /// </summary>
        static InMemoryRecordRepo()
        {
            Records = new List<Record>();

            Record record1 = new Record();
            record1.Id = 1;
            record1.Name = "My Record";

            Records.Add(record1);

            Record record2 = new Record();
            record2.Id = 2;
            record2.Name = "My Other Record";

            Records.Add(record2);
        }

        /// <summary>
        /// The non-static constructor for InMemoryRecordRepo
        /// </summary>
        public InMemoryRecordRepo()
        {
            // Nothing to do here right now.
        }

        /// <summary>
        /// Gets a record by its identifier
        /// </summary>
        /// <param name="id">The identifier of a record.</param>
        /// <returns>If it exists, the record with the given identifier. Otherwise, null.</returns>
        public Record Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the given record to the repository.
        /// </summary>
        /// <param name="record">The record to save.</param>
        /// <returns>The identifier of the created record.</returns>
        public int Create(Record record)
        {
            throw new NotImplementedException();
        }
    }
}
