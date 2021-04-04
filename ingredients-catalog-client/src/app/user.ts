
export class User {
  userName = '';
  fullName = '';
  isLoggedIn = false;
  role = '';
}

export enum UserRole {
  Admin = 'admin',
  User = 'user'
}
