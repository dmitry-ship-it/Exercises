using System;
using System.IO;

namespace SignalStream
{
    internal class SignalStream : Stream
    {
        private readonly Stream _stream;

        public SignalStream(Stream stream)
        {
            _stream = stream;
        }

        public event EventHandler<ReadPercentEventArgs> TenthPartRead;

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position { get => _stream.Position; set => _stream.Position = value; }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var bytesRead = 0;
            var step = (int)_stream.Length / 10;

            // if count of bytes is more than buffer length then use buffer.Length
            var length = count > buffer.Length
                ? buffer.Length
                : count;

            for (var currentPosition = offset; currentPosition < length && currentPosition + step <= _stream.Length; currentPosition += step)
            {
                bytesRead += _stream.Read(buffer, currentPosition, step);
                TenthPartRead?.Invoke(this, new ReadPercentEventArgs(bytesRead / step * 10));
            }

            // read remaining bytes
            // usually remains about a dozen bytes
            if (bytesRead < _stream.Length)
            {
                bytesRead += _stream.Read(buffer, bytesRead, (int)_stream.Length - bytesRead);
            }

            return bytesRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }
    }
}
