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

using System.Runtime.InteropServices;

namespace Crystal.FFXILobbyServer.Network
{
    [StructLayout(LayoutKind.Sequential, Size = FFXIPacket.HEADER_SIZE)]
    public struct FFXIPacketHeader
    {
        public uint packetSize;
        public uint signature;
        public uint opcode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
        public byte[] md5Hash;
    }
}
