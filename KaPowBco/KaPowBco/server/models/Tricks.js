import mongoose from 'mongoose'
const Schema = mongoose.Schema

export const TricksSchema = new Schema(
    {
        creatorId: { type: Schema.Types.ObjectId, required: true },
        name: { type: String, required: true },
        contentUrl: { type: String },
        contentType: { type: String, enum: ['video', 'image'] },
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