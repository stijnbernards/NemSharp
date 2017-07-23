using NemSharp.Request.Responses;

namespace NemSharp.Tests
{
    public class TestConstants
    {
        public const string ACCOUNT_ADDRESS1 = "TC5SVELWEUWA3R2IEZ34337GGZTETKTESUKDSFPS";
        public const string ACCOUNT_PRIVATE_KEY1 = "04e7e06420ace9f6bab010565fcbfcb0b502ba7bb00387665644c096e9c158f4";
        public const string ACCOUNT_PUBLIC_KEY1 = "686349a360c7bec565cb15de1358b106f83f098e38c473eb237d24608e268fd5";

        public const string ACCOUNT_ADDRESS2 = "TBVTPEXRRQ4YDZ4Z6ZL6TDVX5T2J6TAPC54T7MX7";
        public const string ACCOUNT_PRIVATE_KEY2 = "75b2092b7f4792a9396753578f9f83fc97d104d8ddf55d01d395d46e5c2ec71a";
        public const string ACCOUNT_PUBLIC_KEY2 = "f260eee34965498d8171a98b96755b4a01d5b191861e00f7ead15342cc5e5888";

        public static KeyPairViewModel AccountModel1 = new KeyPairViewModel(
                ACCOUNT_PRIVATE_KEY1,
                ACCOUNT_PUBLIC_KEY1,
                ACCOUNT_ADDRESS1
            );

        public static KeyPairViewModel AccountModel2 = new KeyPairViewModel(
                ACCOUNT_PRIVATE_KEY2,
                ACCOUNT_PUBLIC_KEY2,
                ACCOUNT_ADDRESS2
            );
    }
}
