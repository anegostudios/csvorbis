/* OggDecoder
 * Copyright (C) 2002 Mark Crichton <crichton@gimp.org>
 *
 * Written by: Mark Crichton <crichton@gimp.org>
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Library General Public License
 * as published by the Free Software Foundation; either version 2 of
 * the License, or (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Library General Public License for more details.
 *
 * You should have received a copy of the GNU Library General Public
 * License along with this program; if not, write to the Free Software
 * Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
 *
 * 9 January 2024 - Modified by Manuel Dielacher.
 */

using System;
using System.IO;

namespace OggDecoder
{
	/// <summary>
	/// Ogg Vorbis decoder test application.
	/// </summary>
	class Decoder
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Decode(FileStream input, FileStream output) 
		{
			TextWriter s_err = Console.Error;

			OggDecodeStream decode = new OggDecodeStream(input, true);

			byte[] buffer = new byte[4096];
			int read;
			while ((read = decode.Read(buffer, 0, buffer.Length)) > 0)
			{
				output.Write(buffer, 0, read);
			}

			// Close some files
			input.Close();
			output.Close();
		}
	}
}

