import { JwtPayload } from 'jwt-decode';

export interface UserPayload extends JwtPayload {
  name?: string;
  email?: string;
  role?: string | string[];
}
