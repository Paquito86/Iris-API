using TestAPI.Models;

namespace TestAPI.Agents
{
    public class SSHKeyAgent
    {
        //public string? PublicSshKeyWithComment;

        public string SSHGen(string workstation)
        {

            var keygen = new SshKeyGenerator.SshKeyGenerator(2048);

            var privateKey = keygen.ToPrivateKey();
            Console.WriteLine(privateKey);

            var publicSshKeyWithComment = keygen.ToRfcPublicKey(workstation);
            Console.WriteLine(publicSshKeyWithComment);

            return publicSshKeyWithComment;
        }
    }
}
