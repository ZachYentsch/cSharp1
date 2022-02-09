import mongoose from 'mongoose'
import { AccountSchema, ProfileSchema } from '../models/Account'
import { CoachingSchema } from '../models/Coaching';
import { FollowerSchema } from '../models/Follower';
import { TricksSchema } from '../models/Tricks';
import { ValueSchema } from '../models/Value'

class DbContext {
  Values = mongoose.model('Value', ValueSchema);
  Account = mongoose.model('Account', AccountSchema);
  Profiles = mongoose.model('Profile', ProfileSchema, 'accounts');
  Tricks = mongoose.model('Trick', TricksSchema);

  Coaching = mongoose.model('Coaching', CoachingSchema);

  Followers = mongoose.model('Follower', FollowerSchema)
}

export const dbContext = new DbContext()
