import mongoose from 'mongoose'
const Schema = mongoose.Schema

export const TricksSchema = new Schema(
    {
        name: { type: String, required: true },
        imageUrl: { type: String },
        videoUrl: { type: String },
        type: { type: String, enum: ['Aerial', 'Rail', 'Surface', 'Halfpipe'], required: true },
        steps: { type: String, required: true },
        difficulty: { type: Number, min: 0, max: 10 }
    },
    { timestamps: true, toJSON: { virtuals: true } })

TricksSchema.virtual('creator', {
    localField: 'creatorId',
    foreignField: '_id',
    justOne: true,
    ref: 'Account'
})