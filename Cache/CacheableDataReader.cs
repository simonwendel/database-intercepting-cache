namespace Cache
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface", Justification = "Won't bother with that.")]
    public sealed class CacheableDataReader : DbDataReader
    { 
        private DataTable cachedData;

        private DataTableReader dataReader;

        public CacheableDataReader(IDataReader originalReader)
        {
            if (originalReader == null)
            {
                throw new ArgumentNullException("originalReader");
            }

            cachedData = new DataTable();
            cachedData.Locale = originalReader.GetSchemaTable().Locale;
            cachedData.Load(originalReader);

            Reset();
        }

        ~CacheableDataReader()
        {
            ExplicitlyDispose();
        }

        public override int Depth
        {
            get { return dataReader.Depth; }
        }

        public override int FieldCount
        {
            get { return dataReader.FieldCount; }
        }

        public override bool HasRows
        {
            get
            {
                return dataReader.HasRows;
            }
        }

        public override bool IsClosed
        {
            get { return false; }
        }

        public override int RecordsAffected
        {
            get { return dataReader.RecordsAffected; }
        }

        public override object this[string name]
        {
            get { return dataReader[name]; }
        }

        public override object this[int i]
        {
            get { return dataReader[i]; }
        }

        public override void Close()
        {
            Reset();
        }

        public override bool GetBoolean(int i)
        {
            return dataReader.GetBoolean(i);
        }

        public override byte GetByte(int i)
        {
            return dataReader.GetByte(i);
        }

        public override long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return dataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public override char GetChar(int i)
        {
            return dataReader.GetChar(i);
        }

        public override long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return dataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Just keeping semantics with base.")]
        public new IDataReader GetData(int i)
        {
            return dataReader.GetData(i);
        }

        public override string GetDataTypeName(int i)
        {
            return dataReader.GetDataTypeName(i);
        }

        public override DateTime GetDateTime(int i)
        {
            return dataReader.GetDateTime(i);
        }

        public override decimal GetDecimal(int i)
        {
            return dataReader.GetDecimal(i);
        }

        public override double GetDouble(int i)
        {
            return dataReader.GetDouble(i);
        }

        public override IEnumerator GetEnumerator()
        {
            return dataReader.GetEnumerator();
        }

        public override Type GetFieldType(int i)
        {
            return dataReader.GetFieldType(i);
        }

        public override float GetFloat(int i)
        {
            return dataReader.GetFloat(i);
        }

        public override Guid GetGuid(int i)
        {
            return dataReader.GetGuid(i);
        }

        public override short GetInt16(int i)
        {
            return dataReader.GetInt16(i);
        }

        public override int GetInt32(int i)
        {
            return dataReader.GetInt32(i);
        }

        public override long GetInt64(int i)
        {
            return dataReader.GetInt64(i);
        }

        public override string GetName(int i)
        {
            return dataReader.GetName(i);
        }

        public override int GetOrdinal(string name)
        {
            return dataReader.GetOrdinal(name);
        }

        public override DataTable GetSchemaTable()
        {
            return dataReader.GetSchemaTable();
        }

        public override string GetString(int i)
        {
            return dataReader.GetString(i);
        }

        public override object GetValue(int i)
        {
            return dataReader.GetValue(i);
        }

        public override int GetValues(object[] values)
        {
            return dataReader.GetValues(values);
        }

        public override bool IsDBNull(int i)
        {
            return dataReader.IsDBNull(i);
        }

        /// <summary>
        /// Handling multiple sets is not implemented yet.
        /// </summary>
        /// <returns>Never.</returns>
        /// <exception cref="NotImplementedException">Always.</exception>
        public override bool NextResult()
        {
            throw new NotImplementedException();
        }

        public override bool Read()
        {
            return dataReader.Read();
        }

        public void Reset()
        {
            dataReader = new DataTableReader(cachedData);
        }

        private void ExplicitlyDispose()
        {
            if (dataReader != null)
            {
                dataReader.Dispose();
            }

            if (cachedData != null)
            {
                cachedData.Dispose();
            }
        }
    }
}
