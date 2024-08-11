import { AppSession, createAppSession } from '@/lib';
import { useSession } from 'next-auth/react';

function useAppSession(): AppSession {
  const nextAuthSession = useSession();

  const user = nextAuthSession?.data?.user;

  return createAppSession({
    accessToken: user?.accessToken,
    userName: user?.name
  });
}

export const authentication = {
  useAppSession
};