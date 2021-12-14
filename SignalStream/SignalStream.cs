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
            var persentStep = (int)Math.Round(_stream.Length / 10d);

            var length = count > buffer.Length
                ? buffer.Length
                : count;
            for (var i = offset; i < length; i += persentStep)
            {
                if (i + persentStep > _stream.Length)
                {
                    bytesRead += _stream.Read(buffer, i, (int)_stream.Length - i);
                    break;
                }

                bytesRead += _stream.Read(buffer, i, persentStep);

                TenthPartRead?.Invoke(this, new ReadPercentEventArgs() { Percent = bytesRead / persentStep * 10 });
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

        protected virtual void OnTenthPartRead(ReadPercentEventArgs e)
        {
            TenthPartRead?.Invoke(this, e);
        }
    }
}
