using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Desolation.StatePattern
{
    public interface IResetTaskFactory
    {
        /// <summary>
        /// Create unitask and on it completion reset the skill sequence, if it not go to next skill in sequence.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public UniTask Create(CancellationToken cancellationToken);
    }
}
