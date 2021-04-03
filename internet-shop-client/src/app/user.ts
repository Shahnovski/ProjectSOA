
export class User {
  userName: string = "";
  fullName: string = "";
  isLoggedIn: boolean = false;
  role: string = "";
}

export enum UserRole {
  Admin = 'admin',
  User = 'user'
}
