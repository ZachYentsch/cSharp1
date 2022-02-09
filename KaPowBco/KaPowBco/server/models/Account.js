import mongoose from 'mongoose'
const Schema = mongoose.Schema

export const AccountSchema = new Schema(
  {
    subs: [{ type: String, unique: true }],
    email: { type: String, lowercase: true, unique: true },
    name: { type: String, required: true },
    picture: { type: String },
    bannerImg: { type: String },
    // NOTE If you wish to add additional properties do so here\
    location: { type: String },
    biography: { type: String },
    facebook: { type: String },
    youtube: { type: String },
    twitter: { type: String },
    instagram: { type: String },
    isAvailable: { type: Boolean, default: false },
    isTrainer: { type: Boolean, default: false }

  },
  { timestamps: true, toJSON: { virtuals: true } }
)

export const ProfileSchema = new Schema(
  {
    name: { type: String, required: true },
    picture: { type: String }
    // NOTE if you want to make properties from the account public put them here
  },
  { timestamps: true, toJSON: { virtuals: true } }
)
