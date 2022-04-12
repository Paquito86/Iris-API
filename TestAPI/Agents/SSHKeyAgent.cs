using TestAPI.Models;

namespace TestAPI.Agents
{
    public class SSHKeyAgent
    {
        public string? PublicSshKeyWithComment;

        public void SSHGen(string workstation, SSHPubKey key)
        {

            var keygen = new SshKeyGenerator.SshKeyGenerator(2048);

            var privateKey = keygen.ToPrivateKey();
            Console.WriteLine(privateKey);

            var publicSshKey = keygen.ToRfcPublicKey();
            Console.WriteLine(publicSshKey);

            var publicSshKeyWithComment = keygen.ToRfcPublicKey(workstation);
            Console.WriteLine(publicSshKeyWithComment);

            PublicSshKeyWithComment = publicSshKeyWithComment;
        }
    }
}
