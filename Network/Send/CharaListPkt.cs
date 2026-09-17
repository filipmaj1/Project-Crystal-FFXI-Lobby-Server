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
using System.Buffers.Binary;
using System.Linq;
using System.Runtime.InteropServices;

namespace Crystal.FFXILobbyServer.Network.Send
{
    public struct CharaListPkt
    {
        // Pkt Info
        public const int OPCODE = 0x20;

        // Pkt Data
        public uint NumChara;
        public Character[] Characters;

        public readonly byte[] Bytes
        {
            get
            {
                // 2. Use MemoryMarshal on the array span
                ReadOnlySpan<Character> characterSpan = Characters.Reverse().ToArray();
                ReadOnlySpan<byte> characterBytes = MemoryMarshal.AsBytes(characterSpan);

                // 3. Create the final buffer
                byte[] response = new byte[4 + characterBytes.Length];

                // 4. Write the count and the data
                BinaryPrimitives.WriteUInt32LittleEndian(response, NumChara);
                characterBytes.CopyTo(response.AsSpan(4));
                return [.. response];
            }
        }
    }
}
