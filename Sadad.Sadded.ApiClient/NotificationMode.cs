namespace Sadad.Sadded.ApiClient
{
    /// <summary>
    /// System will send the payment link by email or by SMS. In case of 'Online', system will not send payment link by sms or email.
    /// </summary>
    public enum NotificationMode
    {
        Online = 300,
        SMS = 100,
        Email = 200        
    }
}
