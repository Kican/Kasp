using System.IO;
using System.Threading.Tasks;

namespace Kasp.FileStorage.Core {
	// https://github.com/a-patel/LiteXStorage
	public interface IFileProvider {
		Task UploadAsync(string fileName, Stream data);
		Task<Stream> GetAsync(string fileName);
		Task<Stream> GetLinkAsync(string fileName);
	}
}