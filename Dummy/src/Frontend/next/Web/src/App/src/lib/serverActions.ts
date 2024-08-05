'use server';

import { AuthError } from 'next-auth';
import serverContext from '@/lib/serverContext';

export async function authenticate(
  prevState: string | undefined,
  formData: FormData,
) {
  const { signIn } = serverContext.app.authentication.getNextAuth();

  try {
    await signIn('credentials', formData);
  } catch (error) {
    if (error instanceof AuthError) {
      switch (error.type) {
        case 'CredentialsSignin':
          return 'Invalid credentials.';
        default:
          return 'Something went wrong.';
      }
    }
    throw error;
  }
}
