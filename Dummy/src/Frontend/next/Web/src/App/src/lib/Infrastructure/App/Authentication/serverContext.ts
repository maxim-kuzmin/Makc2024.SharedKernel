import { AppSession, createAppSession } from '@/lib';
import modules from "@/lib/modules";

async function getAppSession(): Promise<AppSession> {
  const { auth } = modules.app.authentication.getNextAuth();

  const nextAuthSession = await auth();

  const user = nextAuthSession?.user;

  return createAppSession({
    accessToken: user?.accessToken,
    userName: user?.name
  });
}

export const authentication = {
  getAppSession
};