import { z } from 'zod';

const form = {
  schema: z.object({
    name: z.string(),
  })
};

export default form;