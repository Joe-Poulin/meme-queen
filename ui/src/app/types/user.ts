export class User {
    constructor(public Id: number, public FirstName: string, public LastName: string,
        public PhoneNumber: string, public UsePhoneNumber: boolean, public EmailAddress: string, public UseEmailAddress: boolean,
        public MemeTime: Date) {}
}