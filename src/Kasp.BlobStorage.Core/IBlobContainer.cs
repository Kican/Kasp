using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kasp.BlobStorage.Core {
	public interface IBlobContainer {
		Task SaveAsync(string name, Stream stream, bool overrideExisting = false, CancellationToken cancellationToken = default);
	}
}