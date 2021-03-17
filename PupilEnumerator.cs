using System.Collections;

namespace HackerRank
{
    internal class PupilEnumerator : IEnumerator
    {
        private string[] pupil;

        public PupilEnumerator(string[] pupil)
        {
            this.pupil = pupil;
        }

        object IEnumerator.Current => throw new System.NotImplementedException();

        bool IEnumerator.MoveNext()
        {
            throw new System.NotImplementedException();
        }

        void IEnumerator.Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}