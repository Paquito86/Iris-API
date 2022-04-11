namespace TestAPI.Agents
{
    public class SSHKeyAgent
    {
        public void SSHGen()
        {
            var keygen = new SshKeyGenerator.SshKeyGenerator(2048);

            var privateKey = keygen.ToPrivateKey();
            Console.WriteLine(privateKey);

            var publicSshKey = keygen.ToRfcPublicKey();
            Console.WriteLine(publicSshKey);

            var publicSshKeyWithComment = keygen.ToRfcPublicKey("user@domain.com");
            Console.WriteLine(publicSshKeyWithComment);
        }
    }
}
