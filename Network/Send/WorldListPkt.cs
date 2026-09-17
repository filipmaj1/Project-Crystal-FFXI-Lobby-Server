/*
===========================================================================
Copyright (C) 2019-2026 Project Crystal Dev Team

This file is part of Project Crystal Server.

Project Crystal Server is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Project Crystal Server is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with Project Crystal Server. If not, see <https://www.gnu.org/licenses/>.
===========================================================================
*/

using Crystal.FFXILobbyServer.Network.Models;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Crystal.FFXILobbyServer.Network.Send
{
    public struct WorldListPkt
    {
        // Pkt Info
        public const int OPCODE = 0x23;

        // Pkt Data
        public uint NumWorlds;
        public World[] WorldList;

        public readonly byte[] Bytes
        {
            get
            {
                ReadOnlySpan<World> worldListSpan = new([.. WorldList.Reverse()]);

                Span<byte> response = new byte[4 + (WorldList.Length * World.SIZE)];
                MemoryMarshal.Write(response, in NumWorlds);
                MemoryMarshal.AsBytes(worldListSpan).CopyTo(response[0x4..]);

                return response.ToArray();
            }
        }
    }
}
