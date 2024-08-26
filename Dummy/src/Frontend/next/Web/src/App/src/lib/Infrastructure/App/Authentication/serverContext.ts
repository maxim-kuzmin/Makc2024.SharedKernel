import { AppSession, createAppSession } from '@/lib';
import modules from "@/lib/modules";
import { User } from 'next-auth';

async function getAppSession(): Promise<AppSession> {
  const { auth } = modules.app.authentication.getNextAuth();

  const nextAuthSession = await auth();

  const user = nextAuthSession?.user;

  return createAppSession({
    accessToken: nextAuthSession?.openIdAccessToken ?? user?.accessToken,
    userName: user?.name
  });
}

export const authentication = {
  getAppSession
};