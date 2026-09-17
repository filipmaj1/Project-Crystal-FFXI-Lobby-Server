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

using System;
using System.Runtime.InteropServices;

namespace Crystal.FFXILobbyServer.Network.Receive
{
    public unsafe struct GetCharPkt
    {
        // Pkt Info
        public const int OPCODE = 0x1F;
        public const int SIZE = 0x10;

        // Pkt Data
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
        public readonly byte[] Password;

        public static GetCharPkt Cast(byte[] data)
        {
            fixed (byte* pdata = &data[0])
            {
                return Marshal.PtrToStructure<GetCharPkt>(new IntPtr(pdata));
            }
        }
    }
}
