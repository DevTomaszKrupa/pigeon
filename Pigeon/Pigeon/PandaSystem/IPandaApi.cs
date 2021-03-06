﻿using System.Threading.Tasks;
using Pigeon.PandaSystem.Models;
using RestEase;

namespace Pigeon.PandaSystem
{
    public interface IPandaApi
    {
        [Post("product")]
        Task BulkUpdate([Body] BulkUpdateRequest request);
    }
}
